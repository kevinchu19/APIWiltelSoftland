using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Entities;
using WSCobrosSoftland.Models;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland.Services
{
    public class WSCobrosAuthenticationService
    {

        public WSCobrosAuthenticationRepository Repository { get; }

        public WSCobrosAuthenticationService(WSCobrosAuthenticationRepository repository)
        {
            this.Repository = repository;
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
            
            return false;
        }
    }
}

