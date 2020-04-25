using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland.Services
{
    public class PagarDeudasService: Service
    {
        protected new PagarDeudasRepository Repository { get; }
        protected new Serilog.ILogger Logger { get; }

        public PagarDeudasService(PagarDeudasRepository repository, Serilog.ILogger logger): base(repository, logger)
        {
            Repository = repository;
            Logger = logger;
        }

        
    }
}
