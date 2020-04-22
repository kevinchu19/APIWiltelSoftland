using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Repositories
{
    public class ConsultarEstadoTransaccionRepository
    {
        private readonly Serilog.ILogger logger;

        public WILTELContext Context { get; set; }
        private string Connectionstring { get; set; }

        public ConsultarEstadoTransaccionRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            this.Context = context;
            this.logger = logger;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }


        public async Task<RespEstadoTransaccion> Getall(string codBoca, string codTerminal, string idTransaccion)
        {
            RespEstadoTransaccion response = new RespEstadoTransaccion
            {
                Estado = 0,
                NroOperacion = ""
            };

            SarVtrrch vtrrch = await Context.SarVtrrch.FindAsync(idTransaccion);

            if (vtrrch != null)
            {
                if (vtrrch.UsrVtrrchWsestad == 0)
                {
                    response.NroOperacion = vtrrch.SarVtrrchCodfor + "|" + vtrrch.SarVtrrchNrofor.ToString();
                }
            }
            else
            {
                response.Estado = 300; //Transaccion inexistente
            }

            return response;

        }

    }
}
