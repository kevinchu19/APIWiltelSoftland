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
        public RecuperarDeudasController(RecuperarDeudasRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet]
        public async Task<RespRecuperarDeudas> Get(string autentic1, string autentic2, string codEnte, string clave, string valor)
        {

            //bool Autenticado =  Repository.ValidoAutenticación(autentic1, autentic2);

            RespRecuperarDeudas deudas = new RespRecuperarDeudas();
            
            deudas = await Repository.Getall(codEnte, clave, valor);

            return deudas;
        }
    }

}
