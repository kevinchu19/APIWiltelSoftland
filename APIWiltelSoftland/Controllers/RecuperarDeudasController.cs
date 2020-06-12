using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;
using APIWiltelSoftland.Services;

namespace APIWiltelSoftland.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecuperarDeudasController : ControllerBase
    {
        private readonly Serilog.ILogger logger;

        public RecuperarDeudasService Service { get; }
        public WSCobrosAuthenticationService _AuthenticationService { get; }

        public RecuperarDeudasController(RecuperarDeudasService service, Serilog.ILogger logger, WSCobrosAuthenticationService _AuthenticationService)
        {
            Service = service;
            this.logger = logger;
            this._AuthenticationService = _AuthenticationService;
        }


        /// <summary>
        /// Devuelve deudas pendientes de pago de acuerdo a los parametros ingresados
        /// </summary>
        /// <param name="autentic1"> Usuario </param>
        /// <param name="autentic2"> Contraseña </param>
        /// <param name="codEnte"> Codigo de entidad </param>
        /// <param name="clave"> Valor fijo: nrodoc </param>
        /// <param name="valor"> Numero de documento sobre el cual se desean consultar deudas</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<RespRecuperarDeudas> Get(string autentic1, string autentic2, string codEnte, string clave, string valor)
        {

            RespRecuperarDeudas response = new RespRecuperarDeudas();

            this.logger.Information($"Se recibió consulta de deuda, Ente: {codEnte}, Clave: {clave}, " +
                              $"Valor:{valor}");

            bool Autenticado =  await _AuthenticationService.ValidoAutenticacion(autentic1, autentic2);

            if (Autenticado ==true)
            {
                response = await Service.Get(codEnte, clave, valor);
            }
            else
            {
                response.Estado = 200; //Datos de autenticación incorrectos
            }
            
            this.logger.Information($"Respuesta: {response}");
            return response;
        }
    }

}
