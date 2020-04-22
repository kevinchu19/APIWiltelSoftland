using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Models;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultarEstadoTransaccionController : ControllerBase
    {
        private readonly ConsultarEstadoTransaccionRepository Repository;
        private readonly Serilog.ILogger logger;

        public ConsultarEstadoTransaccionController(ConsultarEstadoTransaccionRepository repository, Serilog.ILogger logger)
        {
            this.Repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<RespEstadoTransaccion> Get(string autentic1, string autentic2, string CodBoca, string CodTerminal, string IdTransaccion)
        {

            this.logger.Information($"Se recibió consulta de transaccion, Boca: {CodBoca}, Terminal: {CodTerminal}, " +
                              $"Id Transaccion:{IdTransaccion}");

            //bool Autenticado =  Repository.ValidoAutenticación(autentic1, autentic2);

            RespEstadoTransaccion response = new RespEstadoTransaccion();

            response = await Repository.Getall(CodBoca, CodTerminal, IdTransaccion);

            this.logger.Information($"Respuesta: {response}");
            return response;
        }
    }

}

