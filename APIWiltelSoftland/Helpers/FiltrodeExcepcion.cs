using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWiltelSoftland.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIWiltelSoftland.Helpers
{
    public class FiltrodeExcepcion : ExceptionFilterAttribute, IExceptionFilter
    {
        private RespEstadoTransaccion respuestaPorExcepcionPost = new RespEstadoTransaccion();
        private RespRecuperarDeudas respuestaPorExcepcionGet = new RespRecuperarDeudas();
        public Serilog.ILogger logger { get; }

        public FiltrodeExcepcion(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {

            logger.Fatal(context.Exception.Message);
            //context.HttpContext.Response.StatusCode = 
            
        }
    }
}
