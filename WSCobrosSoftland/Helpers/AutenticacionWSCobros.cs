
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;

namespace WSCobrosSoftland.Helpers
{
    public class AutenticacionWSCobros
    {
        private WILTELContext Context { get; set; }
        private string Connectionstring { get; set; }

        public AutenticacionWSCobros(WILTELContext context, IConfiguration configuration)
        {
            this.Context = context;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        //private async Task<bool> ValidoAutenticacion(string usuario, string password, string codEnte)
        //{

        //}

    }
}
