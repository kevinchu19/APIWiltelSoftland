
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Entities;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Repositories
{
    public class PagarDeudasRepository: Repository
    { 
        public PagarDeudasRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger Logger):base(context, configuration, Logger)
        {
        }


        public async Task<bool> ExisteTransaccion(string IdTransaccion)
        {
            SarVtrrch vtrrch = await Context.SarVtrrch.FindAsync(IdTransaccion);

            if (vtrrch != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public async Task<RespPagarDeudas> Post(string codBoca, string codTerminal, ComprobanteDeudaSoftland comprobanteDeuda,
                                                                   string codEnte, string idTransaccion, string importe, int status)
        {
            RespPagarDeudas response = new RespPagarDeudas();

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
                UsrVtrrchWsestad = status,
                UsrVtrrchCodboc = codBoca,
                UsrVtrrchCodter = codTerminal,
                UsrVtrrchCodent = Int16.Parse(codEnte)
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

                Logger.Information("Se insertaron registros en tablas SAR_VTRRCH e hijas");
            }
            catch (Exception error)
            {
                Logger.Fatal($"Error al insertar registros en tablas SAR_VTRRCH e hijas:{error}");
                response.Estado = 999;
                response.NroOperacion = "";
            };

            if (status == 0)
            {
                response = await ProcesoRecibo(HeaderCobranza);
            }
            return response;
          
        }

        private async Task<RespPagarDeudas> ProcesoRecibo(SarVtrrch HeaderCobranza)
        {
            RespPagarDeudas resultado = new RespPagarDeudas();

            await InsertaCwJmSchedules("USR_RC");

            //Para dejar tiempo a Softland a que procese el recibo
            Thread.Sleep(10000);

            //Para recargar la entidad con los datos del recibo impactado en Softland.
            await Context.Entry(HeaderCobranza).ReloadAsync();

            switch (HeaderCobranza.SarVtrrchStatus)
            {
                case "S":
                    Logger.Information($"El pago se recibio, procesado por Softland: {resultado.NroOperacion}");
                    resultado.Estado = 0;
                    resultado.NroOperacion = HeaderCobranza.SarVtrrchCodfor + "|" + HeaderCobranza.SarVtrrchNrofor.ToString();
                    break;
                case "N":
                    Logger.Warning($"El pago se recibio, pero Softland aún no lo proceso, SAR_VTRRRCH_IDENTI = {HeaderCobranza.SarVtrrchIdenti}");
                    resultado.Estado = 0;
                    resultado.NroOperacion  = "Pago recibido, numero de comprobante pendiente de confirmar";
                    break;
                case "E":
                    Logger.Warning($"El pago se recibio, la registracion dio error: {HeaderCobranza.SarVtrrchErrmsg}");
                    resultado.Estado = 999;
                    resultado.NroOperacion = "Error interno en aplicación";
                    break;
            }
            
            return resultado;
        }

    }
}
