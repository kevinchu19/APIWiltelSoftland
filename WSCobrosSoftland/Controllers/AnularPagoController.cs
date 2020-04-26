using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Models;
using WSCobrosSoftland.Repositories;
using WSCobrosSoftland.Services;

namespace WSCobrosSoftland.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnularPagoController: ControllerBase
    {
        
        private readonly Serilog.ILogger logger;
        public AnularPagoService Service { get; }
        public WSCobrosAuthenticationService _AuthenticationService { get; }

        public AnularPagoController(AnularPagoService service, Serilog.ILogger logger, WSCobrosAuthenticationService _authenticationService)
        {
            Service = service;
            this.logger = logger;
            this._AuthenticationService = _authenticationService;
        }

        [HttpPost]
        public async Task<RespAnular> Post(string autentic1, string autentic2, string CodBoca, string CodTerminal, string IdTransaccion)
        {

            RespAnular response = new RespAnular();

            this.logger.Information($"Se recibió anulacion de pago, Boca: {CodBoca}, Terminal: {CodTerminal}, " +
                              $"Id Transaccion Pago a anular:{IdTransaccion}");


            bool Autenticado = await _AuthenticationService.ValidoAutenticacion(autentic1, autentic2);

            if (Autenticado == true)
            {
                response = await Service.Post(CodBoca, CodTerminal, IdTransaccion);
            }
            else
            {
                response.Estado = 200; //Datos de autenticación incorrectos
            }

            this.logger.Information($"Respuesta: {response}");
            return response;
        }
    }
}
