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
    public class RecuperarDeudasController : ControllerBase
    {
        private readonly RecuperarDeudasRepository Repository;
        private readonly Serilog.ILogger logger;

        public RecuperarDeudasController(RecuperarDeudasRepository repository, Serilog.ILogger logger)
        {
            this.Repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<RespRecuperarDeudas> Get(string autentic1, string autentic2, string codEnte, string clave, string valor)
        {

            this.logger.Information($"Se recibió consulta de deuda, Ente: {codEnte}, Clave: {clave}, " +
                              $"Valor:{valor}");

            //bool Autenticado =  Repository.ValidoAutenticación(autentic1, autentic2);

            RespRecuperarDeudas response = new RespRecuperarDeudas();
            
            response = await Repository.Getall(codEnte, clave, valor);

            this.logger.Information($"Respuesta: {response}");
            return response;
        }
    }

}
