using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Models;
using WSCobrosSoftland.Repositories;
using WSCobrosSoftland.Services;

namespace WSCobrosSoftland.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultarEstadoTransaccionController : ControllerBase
    {
        private readonly ConsultarEstadoTransaccionRepository Repository;
        private readonly Serilog.ILogger logger;
        public WSCobrosAuthenticationService _AuthenticationService { get; }

        public ConsultarEstadoTransaccionController(ConsultarEstadoTransaccionRepository repository, Serilog.ILogger logger, WSCobrosAuthenticationService _authenticationService)
        {
            this.Repository = repository;
            this.logger = logger;
            this._AuthenticationService = _authenticationService;
        }

        

        [HttpGet]
        public async Task<RespEstadoTransaccion> Get(string autentic1, string autentic2, string CodBoca, string CodTerminal, string IdTransaccion)
        {

            RespEstadoTransaccion response = new RespEstadoTransaccion();

            this.logger.Information($"Se recibió consulta de transaccion, Boca: {CodBoca}, Terminal: {CodTerminal}, " +
                              $"Id Transaccion:{IdTransaccion}");

            
            bool Autenticado = await _AuthenticationService.ValidoAutenticacion(autentic1, autentic2);

            if (Autenticado == true)
            {
                response = await Repository.Getall(CodBoca, CodTerminal, IdTransaccion);
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

