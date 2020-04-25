using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland.Services
{
    public class ConsultarEstadoTransaccionService: Service
    {
        protected new ConsultarEstadoTransaccionRepository Repository { get; }
        protected new Serilog.ILogger Logger { get; }

        public ConsultarEstadoTransaccionService(ConsultarEstadoTransaccionRepository repository, Serilog.ILogger logger): base(repository, logger)
        {
            Repository = repository;
            Logger = logger;
        }

        
    }
}
