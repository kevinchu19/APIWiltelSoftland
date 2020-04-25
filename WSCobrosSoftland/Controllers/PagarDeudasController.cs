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
        private readonly PagarDeudasRepository Repository;
        private readonly Serilog.ILogger logger;
        public WSCobrosAuthenticationService _AuthenticationService { get; }

        public PagarDeudasController(PagarDeudasRepository repository, Serilog.ILogger logger, WSCobrosAuthenticationService _AuthenticationService)
        {
            this.Repository = repository;
            this.logger = logger;
            this._AuthenticationService = _AuthenticationService;
        }

        [HttpPost]
        public async Task<RespEstadoTransaccion> Post(string autentic1, string autentic2, 
                                               string CodBoca, string CodTerminal,
                                               string CodDeuda, string CodEnte,
                                               string IdTransaccion, string Importe)
        {

            RespEstadoTransaccion response = new RespEstadoTransaccion();

            this.logger.Information($"Se recibió pago, Boca: {CodBoca}, Terminal {CodTerminal}, " +
                                    $"Deuda:{CodDeuda}, Ente: {CodEnte}, Importe: {Importe}");


            bool Autenticado = await _AuthenticationService.ValidoAutenticacion(autentic1, autentic2);

            if (Autenticado == true)
            {
                response = await Repository.Post(CodBoca, CodTerminal,
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

