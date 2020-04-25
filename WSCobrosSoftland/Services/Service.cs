using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland.Services
{
    public class Service
    {
        protected Repository Repository { get; }
        protected Serilog.ILogger Logger { get; }

        public Service(Repository repository, Serilog.ILogger logger)
        {
            Repository = repository;
            Logger = logger;
        }
    }
}
