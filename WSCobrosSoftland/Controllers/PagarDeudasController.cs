using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Models;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PagarDeudasController : ControllerBase
    {
        private readonly PagarDeudasRepository Repository;
        private readonly Serilog.ILogger logger;

        public RespEstadoTransaccion response{ get; set; }

        public PagarDeudasController(PagarDeudasRepository repository, Serilog.ILogger logger)
        {
            this.Repository = repository;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<RespEstadoTransaccion> Post(string autentic1, string autentic2, 
                                               string CodBoca, string CodTerminal,
                                               string CodDeuda, string CodEnte,
                                               string IdTransaccion, string Importe)
        {

            this.logger.Information($"Se recibió pago, Boca: {CodBoca}, Terminal {CodTerminal}, " +
                                    $"Deuda:{CodDeuda}, Ente: {CodEnte}, Importe: {Importe}");

            response = await Repository.Post(CodBoca, CodTerminal,
                                             CodDeuda, CodEnte,
                                             IdTransaccion,Importe);
            logger.Information($"Respuesta:{response.ToString()}");

            return response;
        }
    }
}

