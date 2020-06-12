using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;

namespace APIWiltelSoftland.Services
{
    public class WSCobrosAuthenticationService: Service
    {

        protected new WSCobrosAuthenticationRepository Repository { get; }

        public WSCobrosAuthenticationService(WSCobrosAuthenticationRepository repository, Serilog.ILogger logger):base(repository, logger)
        {
            Repository = repository;
        }

        public async Task<bool> ValidoAutenticacion(string autentic1, string autentic2)
        {
            List<UsrWstush> usuarios = new List<UsrWstush>();

            usuarios = await Repository.RecuperaUsuarios();

            if (usuarios.Count > 0)
            {
                foreach (var usuario in usuarios)
                {
                    if (usuario.UsrWstushUserid == autentic1 && usuario.UsrWstushUsrpwd == autentic2)
                    {
                        return true;
                    }
                }
            }

            Logger.Warning($"Autenticación fallida - Usuario:{autentic1}, Password: {autentic2}");
            return false;
        }
    }
}

