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

        public PagarDeudasController(PagarDeudasRepository repository)
        {
            this.Repository = repository;
        }

        [HttpPost]
        public async Task<RespEstadoTransaccion> Post(string autentic1, string autentic2, 
                                               string CodBoca, string CodTerminal,
                                               string CodDeuda, string CodEnte,
                                               string IdTransaccion, string Importe)
        {
            RespEstadoTransaccion response = new RespEstadoTransaccion();

            response = await Repository.Post(CodBoca, CodTerminal,
                                             CodDeuda, CodEnte,
                                             IdTransaccion,Importe);

            return response;
        }
    }
}

