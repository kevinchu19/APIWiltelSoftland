using APIWiltelSoftland.Helpers;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;
using APIWiltelSoftland.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController: ControllerBase
    {
        public Serilog.ILogger logger { get; }
        public ContratoService Service { get; }

        public ContratoController(Serilog.ILogger logger, ContratoService service)
        {
            this.logger = logger;
            Service = service;
        }

        /// <summary>
        /// Permite modificar el estado de un contrato a través de un JSONPatchDocument enviado en el body
        /// </summary>
        /// <remarks>Composicion del json patch document: <br></br>
        ///  - op: Operacion. Indica el tipo de operacion a realizar (siempre valor "replace")<br></br>
        ///  - path: Indica nombre del campo a modificar (siempre valor "/CvmtchEstact")<br></br>
        ///  - value: Indica nuevo valor a actualizar del campo asignado en el path
        /// </remarks>
        /// <param name="codemp">Codigo de Empresa del contrato</param>
        /// <param name="codcon">Tipo de contrato</param>
        /// <param name="nrocon">Código de contrato</param>
        /// <param name="nroext">Número de extensión</param>
        /// <param name="fechacierreot">Fecha de cierre de la orden de trabajo que generó el cambio de estado (Formato: AAAA/MM/DD)</param>
        /// <param name="patchDocument">Objeto "JsonPatchDocument" para realizar el cambio de estado del contrato</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Estado del contrato modificado sin impedimentos. </response>        
        /// <response code="404">Not Found. No se ha encontrado el contrato solicitado.</response>
        /// <response code="400">Bad Request. Existe un error de validación que no permite modificar el contrato, vendrá acompañado con su correspondiente mensaje.</response>
        /// <returns></returns>
        [HttpPatch("{codemp}/{codcon}/{nrocon}/{nroext}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIWiltelResponse>> Patch(string codemp, string codcon, string nrocon, int nroext, DateTime fechacierreot ,[FromBody] JsonPatchDocument patchDocument)
        {
            APIWiltelResponse response = new APIWiltelResponse { };

            logger.Information($"Se recibió una solicitud de cambio de estado del contrato: {codemp} - {codcon} - {nrocon} - {nroext}. Fecha de cierre de OT: {fechacierreot}");

            if (patchDocument == null | !ModelState.IsValid) 
            {
                throw new BadRequestException("No se recibió cuerpo de la petición o el mismo tiene un formato incorrecto");       
            }

            var editablePaths = new List<string> { "/CvmcthEstact" };

            if (patchDocument.Operations.Any(operation => editablePaths.Contains(operation.path)))
            {
                await Service.Patch(codemp, codcon, nrocon, nroext, fechacierreot, patchDocument);
                return new APIWiltelResponse
                {
                    estado = 200,
                    titulo = "Transacción ok",
                    mensaje = "El contrato ha sido modificado exitosamente."
                };
            }
            else
            {
                throw new BadRequestException("Sólo se puede editar el estado del contrato.");
            }           

        }
    }
}
