
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
        public WILTELContext Context { get; set; }
        private string Connectionstring { get; set; }

        public PagarDeudasRepository(WILTELContext context, IConfiguration configuration)
        {
            this.Context = context;
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
                response.Estado = 4;
                response.NroOperacion = "";

                return response;
            }
            
            if (comprobanteDeuda.Fchvnc.Date < DateTime.Now.Date)
            {
                response.Estado = 3;
                response.NroOperacion = "";

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

            Context.SarVtrrch.Add(HeaderCobranza);

            await Context.SaveChangesAsync();

            Context.SarVtrrcc01.Add(AplicacionesCobranza);

            await Context.SaveChangesAsync();

            Context.SarVtrrcc04.Add(MediosdeCobro);

            await Context.SaveChangesAsync();

            await InsertaCwJmSchedules("USR_RC");

            //Para dejar tiempo a Softland a que procese el recibo
            Thread.Sleep(6000);

            SarVtrrch ReciboGenerado = await Context.SarVtrrch.FindAsync(idTransaccion);

            string nroOperacion = ReciboGenerado.SarVtrrchCodfor + "|" + ReciboGenerado.SarVtrrchNrofor.ToString();

            return new RespEstadoTransaccion
            {
                Estado = 0,
                NroOperacion = "1"
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

                return response;
            }
        }

        private async Task<ComprobanteDeudaSoftland> RecuperarComprobanteDeuda(string identificadorDeuda)
        {
            string sSql = "SELECT " + 
                " VTRMVH_CODEMP, VTRMVH_MODFOR, VTRMVH_CODFOR, VTRMVH_NROFOR, VTRMVC_FCHVNC, VTRMVC_IMPNAC, VTRMVH_NROCTA " +
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

                        }
                    }
                }

                return response;
            }

        }
    }
}
