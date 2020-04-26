using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WSCobrosSoftland.Models;
using WSCobrosSoftland.Repositories;
using WSCobrosSoftland.Services;

namespace WSCobrosSoftland.Controllers
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
                response = await Service.Post(CodBoca, CodTerminal,
                                                 CodDeuda, CodEnte,
                                                 IdTransaccion, Importe);
            }
            else
            {
                response.Estado = 200; //Datos de autenticación incorrectos
            }

            logger.Information($"Respuesta:{Response.ToString()}");

            return response;
        }
    }
}

