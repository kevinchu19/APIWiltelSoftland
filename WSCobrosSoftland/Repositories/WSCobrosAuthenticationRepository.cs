using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Entities;

namespace WSCobrosSoftland.Repositories
{
    public class WSCobrosAuthenticationRepository: Repository
    {

        public WSCobrosAuthenticationRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger): base(context, configuration, logger)
        {
        }

        public async Task<List<UsrWstush>> RecuperaUsuarios()
        {
            return await Context.UsrWstush.ToListAsync();
        }
    }
}
