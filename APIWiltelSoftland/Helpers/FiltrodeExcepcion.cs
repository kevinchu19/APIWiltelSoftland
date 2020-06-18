using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWiltelSoftland.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

            var exception = context.Exception;

            APIWiltelResponse response = new APIWiltelResponse {
                estado = 500,
                titulo = "Error interno de la aplicación",
                mensaje = exception.Message
            };
            context.Result = new ObjectResult(response);
            context.HttpContext.Response.StatusCode =
                      (int)HttpStatusCode.InternalServerError;

            switch (context.Exception.GetType().ToString())
            {
                case "APIWiltelSoftland.Helpers.BadRequestException":
                    response.estado = 400;
                    response.titulo = "Bad Request";
                    context.Result = new BadRequestObjectResult(response);
                    context.HttpContext.Response.StatusCode =
                        (int)HttpStatusCode.BadRequest;
                    break;
                case "APIWiltelSoftland.Helpers.NotFoundException":
                    response.estado = 404;
                    response.titulo = "Not Found";
                    context.Result = new NotFoundObjectResult(response);
                    context.HttpContext.Response.StatusCode =
                        (int)HttpStatusCode.NotFound;
                    break;
                default:
                    break;
            }
           
            context.ExceptionHandled = true;

        }
    }
}
