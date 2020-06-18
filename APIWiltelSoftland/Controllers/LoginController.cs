using APIWiltelSoftland.Models;
using APIWiltelSoftland.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController: ControllerBase
    {
        private readonly Serilog.ILogger logger;
        private APIWiltelLoginService Service { get; }

        public LoginController(APIWiltelLoginService service, Serilog.ILogger logger)
        {
            Service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Permite obtener el token de acceso para la utilización de los endpoints protegidos.
        /// </summary>
        /// <remarks>
        /// Consiste en el envio de un usuario y una contraseña y se retorna un objeto JSON con el atributo "token" que será válido durante 1 hora.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            var token = await Service.LoginWithJwt(usuario.userid, usuario.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new APIWIltelLoginResponse {
                token = token
            });
        }
    }


}
