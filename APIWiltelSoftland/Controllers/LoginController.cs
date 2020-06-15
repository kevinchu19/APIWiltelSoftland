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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            var token = await Service.LoginWithJwt(usuario.userid, usuario.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }


}
