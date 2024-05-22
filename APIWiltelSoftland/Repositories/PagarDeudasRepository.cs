
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Models;

namespace APIWiltelSoftland.Repositories
{
    public class PagarDeudasRepository: Repository
    { 
        public PagarDeudasRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger Logger, WILTELPagosContext contextPagos)
            :base(context, configuration, Logger)
        {
            ContextPagos = contextPagos;
        }

        public WILTELPagosContext ContextPagos { get; }

        public async Task<bool> ExisteTransaccion(string IdTransaccion)
        {
            SarVtrrch vtrrch = await Context.SarVtrrch.FindAsync(IdTransaccion);
            SarVtrrch vtrrchPagos = await ContextPagos.SarVtrrch.FindAsync(IdTransaccion);

            if (vtrrch != null || vtrrchPagos != null)
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
                SarVtrrchStatus = "W",
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
                UsrVtrrchCodent = Int16.Parse(codEnte),
                UsrVtrrchUtpaor = "S"
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
                SarVtrrcc01Cannac = Convert.ToDecimal(importe),
                SarVtrrcc01Canext = null,
                SarVtOalias = "SAR_VTRRCC",
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
                SarVtrrcc04Import = Convert.ToDecimal(importe),
                SarVtOalias = "SAR_VTRRCC",
                SarVtFecalt = DateTime.Now,
                SarVtFecmod = DateTime.Now,
                SarVtUserid = "WEBAPI",
                SarVtUltopr = "A",
                SarVtDebaja = "N"
            };

            try
            {
                ContextPagos.SarVtrrch.Add(HeaderCobranza);

                //await ContextPagos.SaveChangesAsync();

                ContextPagos.SarVtrrcc01.Add(AplicacionesCobranza);

                //await ContextPagos.SaveChangesAsync();

                ContextPagos.SarVtrrcc04.Add(MediosdeCobro);

                await ContextPagos.SaveChangesAsync();

              //  Logger.Information("Se insertaron registros en tablas SAR_VTRRCH e hijas");
            }
            catch (Exception error)
            {
                Logger.Fatal($"Error al insertar registros en tablas SAR_VTRRCH e hijas:{error}");
                response.Estado = 999;
                response.NroOperacion = "Error al procesar el registro de cobro";
                return response;
            };
            
            response = await ProcesoRecibo(HeaderCobranza);
            
            return response;
          
        }

        private async Task<RespPagarDeudas> ProcesoRecibo(SarVtrrch HeaderCobranza)
        {
            RespPagarDeudas resultado = new RespPagarDeudas();

            await InsertaCwJmSchedules("WSCOBR");

            //Para dejar tiempo a Softland a que procese el recibo
            //Se comenta el 13/11/2020 a pedido de Diego Ballario (Mail 28/10/2020)
            //Thread.Sleep(15000);

            //Para recargar la entidad con los datos del recibo impactado en Softland.
            //await Context.Entry(HeaderCobranza).ReloadAsync();

            switch (HeaderCobranza.SarVtrrchStatus)
            {
                case "S":
                    Logger.Information($"El pago se recibio, procesado por Softland: {resultado.NroOperacion}");
                    resultado.Estado = 0;
                    resultado.NroOperacion = HeaderCobranza.SarVtrrchCodfor + "|" + HeaderCobranza.SarVtrrchNrofor.ToString();
                    break;
                case "W":
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
