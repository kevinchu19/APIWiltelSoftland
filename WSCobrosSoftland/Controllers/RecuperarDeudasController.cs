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
    public class RecuperarDeudasController : ControllerBase
    {
        private readonly RecuperarDeudasRepository Repository;
        private readonly Serilog.ILogger logger;
        public WSCobrosAuthenticationService _AuthenticationService { get; }

        public RecuperarDeudasController(RecuperarDeudasRepository repository, Serilog.ILogger logger, WSCobrosAuthenticationService _AuthenticationService)
        {
            this.Repository = repository;
            this.logger = logger;
            this._AuthenticationService = _AuthenticationService;
        }

        

        [HttpGet]
        public async Task<RespRecuperarDeudas> Get(string autentic1, string autentic2, string codEnte, string clave, string valor)
        {

            RespRecuperarDeudas response = new RespRecuperarDeudas();

            this.logger.Information($"Se recibió consulta de deuda, Ente: {codEnte}, Clave: {clave}, " +
                              $"Valor:{valor}");

            bool Autenticado =  await _AuthenticationService.ValidoAutenticacion(autentic1, autentic2);

            if (Autenticado ==true)
            {
                response = await Repository.Getall(codEnte, clave, valor);
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
