using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;
using APIWiltelSoftland.Services;

namespace APIWiltelSoftland.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PagarDeudasController : ControllerBase
    {
        private readonly PagarDeudasService Service;
        private readonly Serilog.ILogger logger;
        public WSCobrosAuthenticationService _AuthenticationService { get; }

        public PagarDeudasController(PagarDeudasService service, Serilog.ILogger logger, WSCobrosAuthenticationService _AuthenticationService)
        {
            this.Service = service;
            this.logger = logger;
            this._AuthenticationService = _AuthenticationService;
        }


        /// <summary>
        /// Genera un recibo en el sistema ERP
        /// </summary>
        /// <param name="autentic1">Usuario</param>
        /// <param name="autentic2">Contraseña</param>
        /// <param name="CodBoca">Codigo de boca</param>
        /// <param name="CodTerminal">Codigo de Terminal</param>
        /// <param name="CodDeuda">Identificador de comprobante cancelado por el pago</param>
        /// <param name="CodEnte">Codigo de ente</param>
        /// <param name="IdTransaccion">Identificador unívoco de transaccion</param>
        /// <param name="Importe">Importe pagado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RespPagarDeudas> Post(string autentic1, string autentic2, 
                                               string CodBoca, string CodTerminal,
                                               string CodDeuda, string CodEnte,
                                               string IdTransaccion, string Importe)
        {

            RespPagarDeudas response = new RespPagarDeudas();

            this.logger.Information($"Se recibió pago, Boca: {CodBoca}, Terminal {CodTerminal}, " +
                                    $"Deuda:{CodDeuda}, Ente: {CodEnte}, Importe: {Importe}" +
                                    $", Identi:{IdTransaccion}");


            bool Autenticado = await _AuthenticationService.ValidoAutenticacion(autentic1, autentic2);

            if (Autenticado == true)
            {
                if (CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator == ".") //punto como separador decimal
                {
                    Importe = Importe.Replace(",", ".");
                }
                if (CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator == ",") //coma como separador decimal
                {
                    Importe = Importe.Replace(".", ",");
                }
                response = await Service.Post(CodBoca, CodTerminal,
                                                 CodDeuda, CodEnte,
                                                 IdTransaccion, Importe);
            }
            else
            {
                response.Estado = 200; //Datos de autenticación incorrectos
            }

            logger.Information($"Respuesta:{response.ToString()}");

            return response;
        }
    }
}

