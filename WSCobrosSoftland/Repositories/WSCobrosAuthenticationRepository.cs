using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Entities;
using WSCobrosSoftland.Models;

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
