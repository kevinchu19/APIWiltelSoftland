using Microsoft.Extensions.Configuration;
using WSCobrosSoftland.Contexts;

namespace WSCobrosSoftland.Repositories
{
    public class Repository
    {
        protected WILTELContext Context { get; }
        protected IConfiguration Configuration { get; }
        protected Serilog.ILogger Logger { get; }
        protected string Connectionstring { get; }

        public Repository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            Context = context;
            Configuration = configuration;
            Logger = logger;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

    }
}
