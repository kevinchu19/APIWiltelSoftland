using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Helpers
{
    public class FiltrodeExcepcion : ExceptionFilterAttribute
    {
        private RespEstadoTransaccion respuestaPorExcepcionPost = new RespEstadoTransaccion();
        private RespRecuperarDeudas respuestaPorExcepcionGet = new RespRecuperarDeudas();

        public override void OnException(ExceptionContext context)
        {
            

            //if (context.ActionDescriptor.ToString() == "WSCobrosSoftland.Controllers.PagarDeudasController.Post")
            //{
            //    respuestaPorExcepcionPost.Estado = 999;
            //    respuestaPorExcepcionPost.NroOperacion = context.Exception.ToString();
            //    context.HttpContext.Response.Body = respuestaPorExcepcionPost;
            //}

            //if (context.ActionDescriptor.ToString() == "WSCobrosSoftland.Controllers.RecuperarDeudasController.Get")
            //{
            //    respuestaPorExcepcionGet.Estado = 999;
            //}

            
        }
    }
}
