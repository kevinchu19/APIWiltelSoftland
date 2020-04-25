using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Entities;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Repositories
{
    public class ConsultarEstadoTransaccionRepository: Repository
    {

        public ConsultarEstadoTransaccionRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger): base(context, configuration, logger)
        {
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
                response.Estado = vtrrch.UsrVtrrchWsestad;
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
