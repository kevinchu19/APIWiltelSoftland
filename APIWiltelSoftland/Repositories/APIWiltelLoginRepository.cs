using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Repositories
{
    public class APIWiltelLoginRepository :Repository
    {
        private readonly Serilog.ILogger logger;

        public APIWiltelLoginRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger) : 
            base(context, configuration, logger)
        {
            this.logger = logger;
        }

        public async Task<List<UsrWstush>> RecuperaUsuarios()
        {
            return await Context.UsrWstush.ToListAsync();
        }
    }
}
