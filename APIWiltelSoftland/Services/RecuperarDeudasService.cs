using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;

namespace APIWiltelSoftland.Services
{
    public class RecuperarDeudasService: Service
    {
        protected new RecuperarDeudasRepository Repository { get; }
        protected int Estado { get; set; } = 0;
        protected List<Deudas> deudas { get; set; } = new List<Deudas>();

        public RecuperarDeudasService(RecuperarDeudasRepository repository, Serilog.ILogger logger): base(repository, logger)
        {
            Repository = repository;
        }

        public async Task<RespRecuperarDeudas> Get(string codEnte, string clave, string valor)
        {
            deudas = await Repository.GetDeudas(codEnte, clave, valor);

            if (deudas.Count == 0)
            {
                Estado = 1; //No se han encontrado pendientes para la identificacion ingresada
                Logger.Warning("No se han encontrado pendientes para la identificacion ingresada");
            }

            return new RespRecuperarDeudas
            {
                Estado = this.Estado,
                Deudas = this.deudas
            };

        }
    }
}
