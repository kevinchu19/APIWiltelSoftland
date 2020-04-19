
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Repositories
{
    public class PagarDeudasRepository
    {
        private readonly Serilog.ILogger logger;

        public WILTELContext Context { get; set; }
        private string Connectionstring { get; set; }

        public PagarDeudasRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            this.Context = context;
            this.logger = logger;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<RespEstadoTransaccion> Post (string CodBoca, string CodTerminal,
                                               string CodDeuda, string CodEnte,
                                               string IdTransaccion, string Importe)
        {
            
            RespEstadoTransaccion response = new RespEstadoTransaccion();
            response.Estado = 0;

            ComprobanteDeudaSoftland comprobanteDeuda = await RecuperarComprobanteDeuda(CodDeuda);

            if (comprobanteDeuda.Codfor == null)
            {
                response.Estado = 4; // Codigo de Deuda inexistente
                response.NroOperacion = "";
                logger.Warning($"Codigo de Deuda inexistente, Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
                return response;
            }
            
            if (comprobanteDeuda.Fchvnc.Date < DateTime.Now.Date)
            {
                response.Estado = 3; //Deuda vencida
                response.NroOperacion = "";
                logger.Warning($"Deuda vencida, el día {comprobanteDeuda.Fchvnc.Date} - Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
                return response;
            }

            if (comprobanteDeuda.Saldo == 0)
            {
                response.Estado = 7; // La deuda ya fue cancelada
                response.NroOperacion = "";
                logger.Warning($"La deuda ya fue cancelada - Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
                return response;
            }


            if (comprobanteDeuda.Saldo < Convert.ToDecimal(Importe))
            {
                response.Estado = 10; //El importe no puede ser superior al monto adeudado del comprobante
                response.NroOperacion = "";
                logger.Warning($"El importe no puede ser superior al monto adeudado del comprobante - " +
                    $"Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
                return response;
            }

            response =  await InsertoRegistros(CodBoca, CodTerminal,
                                                comprobanteDeuda, CodEnte,
                                                (IdTransaccion + Guid.NewGuid()).Substring(1,40), Importe);
            
            return response;

        }

        private async Task<RespEstadoTransaccion> InsertoRegistros(string codBoca, string codTerminal, ComprobanteDeudaSoftland comprobanteDeuda, 
                                                                   string codEnte, string idTransaccion, string importe)
        {
            SarVtrrch HeaderCobranza = new SarVtrrch
            {
                SarVtrrchIdenti = idTransaccion,
                SarVtrrchStatus = "N",
                SarVtrrchCodcom = await RecuperarEquivalencia("WEBSER", "CODCOM", codEnte),
                SarVtrrchNrocta = comprobanteDeuda.Nrocta,
                SarVtrrchCodemp = "WILTEL2",
                SarVtrrchFchmov = DateTime.Now.Date,
                SarVtFecalt = DateTime.Now,
                SarVtFecmod = DateTime.Now,
                SarVtDebaja = "N",
                SarVtOalias = "SAR_VTRRCH",
                SarVtrrchErrmsg = "",
                SarVtUltopr = "A",
                SarVtUserid = "WEBAPI",
            };


            SarVtrrcc01 AplicacionesCobranza = new SarVtrrcc01
            {
                SarVtrrcc01Identi = idTransaccion,
                SarVtrrcc01Nroitm = 1,
                SarVtrrcc01Modapl = comprobanteDeuda.Modfor,
                SarVtrrcc01Codapl = comprobanteDeuda.Codfor,
                SarVtrrcc01Nroapl = comprobanteDeuda.Nrofor,
                SarVtrrcc01Cuotas = 1,
                SarVtrrcc01Impnac = null,
                SarVtrrcc01Impext = null,
                SarVtrrcc01Cannac = comprobanteDeuda.Import,
                SarVtrrcc01Canext = null,
                SarVtFecalt = DateTime.Now,
                SarVtFecmod = DateTime.Now,
                SarVtUserid = "WEBAPI",
                SarVtUltopr = "A",
                SarVtDebaja = "N"
            };

            SarVtrrcc04 MediosdeCobro = new SarVtrrcc04
            {
                SarVtrrcc04Identi = idTransaccion,
                SarVtrrcc04Nroitm = 1,
                SarVtrrcc04Modcpt = null,
                SarVtrrcc04Tipcpt = await RecuperarEquivalencia("WEBSER", "TIPCPT", codEnte),
                SarVtrrcc04Codcpt = await RecuperarEquivalencia("WEBSER", "CODCPT", codEnte),
                SarVtrrcc04Import = comprobanteDeuda.Import,
                SarVtFecalt = DateTime.Now,
                SarVtFecmod = DateTime.Now,
                SarVtUserid = "WEBAPI",
                SarVtUltopr = "A",
                SarVtDebaja = "N"
            };

            try
            {
                Context.SarVtrrch.Add(HeaderCobranza);

                await Context.SaveChangesAsync();

                Context.SarVtrrcc01.Add(AplicacionesCobranza);

                await Context.SaveChangesAsync();

                Context.SarVtrrcc04.Add(MediosdeCobro);

                await Context.SaveChangesAsync();

                logger.Information("Se insertaron registros en tablas SAR_VTRRCH e hijas");
            }
            catch (Exception error)
            {
                logger.Fatal($"Error al insertar registros en tablas SAR_VTRRCH e hijas:{error}");
            };
            

            await InsertaCwJmSchedules("USR_RC");

            logger.Information("Se insertó cwjmschedules");
            
            //Para dejar tiempo a Softland a que procese el recibo
            Thread.Sleep(10000);

            //Para recargar la entidad con los datos del recibo impactado en Softland.
            await Context.Entry(HeaderCobranza).ReloadAsync();

            string nroOperacion = "";
            if (HeaderCobranza.SarVtrrchCodfor == null)
            {
                logger.Warning($"El pago se recibio, pero Softland aún no lo proceso, SAR_VTRRRCH_IDENTI = {HeaderCobranza.SarVtrrchIdenti}");
                nroOperacion = "Pago aceptado, numero de comprobante pendiente de confirmar";
            }
            else
            {
                nroOperacion = HeaderCobranza.SarVtrrchCodfor + "|" + HeaderCobranza.SarVtrrchNrofor.ToString();
                logger.Information($"El pago se recibio, procesado por Softland: {nroOperacion}");
            }
           
            return new RespEstadoTransaccion
            {
                Estado = 0,
                NroOperacion = nroOperacion
            };
        }

        private async Task InsertaCwJmSchedules(string codjob)
        {
            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("ALM_InsCwJmSchedules", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CODJOB", codjob));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    
                }
            }
        }

        private async Task<string> RecuperarEquivalencia(string codigo, string codi01, string codi02)
        {
            string sSql = "SELECT " +
                " INTEQE_CODEQU " +
                " FROM INTEQE " +
                " WHERE " +
                $" INTEQE_CODIGO = '{codigo}' AND " + 
                $" INTEQE_CODI01 = '{codi01}' AND " +
                $" INTEQE_CODI02 = '{codi02}' ";

            string response = "";

            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, sql))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = (string)reader["INTEQE_CODEQU"];
                        }
                    }
                }

                if (response == "")
                {
                    logger.Warning($"No existe la equivalencia - Codigo origen 1: {codi01} - Codigo origen 2: {codi02}, para el registro {codigo}");
                }
                return response;
            }
        }

        private async Task<ComprobanteDeudaSoftland> RecuperarComprobanteDeuda(string identificadorDeuda)
        {
            string sSql = "SELECT " + 
                " VTRMVH_CODEMP, VTRMVH_MODFOR, VTRMVH_CODFOR, VTRMVH_NROFOR, VTRMVC_FCHVNC, VTRMVC_IMPNAC, VTRMVH_NROCTA, " +
                " ISNULL((SELECT SUM(VTRMVC_IMPNAC) FROM VTRMVC " +
                " WHERE " +
                " VTRMVC_EMPAPL = VTRMVH_CODEMP AND " +
                " VTRMVC_MODAPL = VTRMVH_MODFOR AND " +
                " VTRMVC_CODAPL = VTRMVH_CODFOR AND " +
                " VTRMVC_NROAPL = VTRMVH_NROFOR ),0) SALDO " +
                " FROM VTRMVH " +
                " INNER JOIN VTRMVC ON " +
                " VTRMVC_CODEMP = VTRMVH_CODEMP AND " +
                " VTRMVC_MODFOR = VTRMVH_MODFOR AND " +
                " VTRMVC_CODFOR = VTRMVH_CODFOR AND " +
                " VTRMVC_NROFOR = VTRMVH_NROFOR AND " +
                " VTRMVC_CODFOR = VTRMVC_CODAPL " +
                " WHERE " +
                $" USR_VTRMVH_IDC = '{identificadorDeuda}' ";

            ComprobanteDeudaSoftland response = new ComprobanteDeudaSoftland();

            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, sql))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Codemp = (string)reader["VTRMVH_CODEMP"];
                            response.Modfor = (string)reader["VTRMVH_MODFOR"];
                            response.Codfor = (string)reader["VTRMVH_CODFOR"];
                            response.Nrofor = (int)reader["VTRMVH_NROFOR"];
                            response.Fchvnc = (DateTime)reader["VTRMVC_FCHVNC"];
                            response.Import = (decimal)reader["VTRMVC_IMPNAC"];
                            response.Nrocta= (string)reader["VTRMVH_NROCTA"];
                            response.Saldo= (decimal)reader["SALDO"];

                        }
                    }
                }

                return response;
            }

        }
    }
}
