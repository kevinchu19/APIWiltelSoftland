using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Entities;
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
        public async Task<RecuperarDeudasDTO> Get()
        {
            var deudas = await Repository.Getall();

            return new RecuperarDeudasDTO
            {
                Estado = 0,
                ListaDeudas = deudas
            };
        }
    }

}
