using APIWiltelSoftland.Helpers;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;
using APIWiltelSoftland.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        /// <param name="codemp">Codigo de Empresa del contrato</param>
        /// <param name="codcon">Tipo de contrato</param>
        /// <param name="nrocon">Código de contrato</param>
        /// <param name="nroext">Número de extensión</param>
        /// <returns></returns>
        [HttpPatch("{codemp}/{codcon}/{nrocon}/{nroext}")]
        public async Task<ActionResult<APIWiltelResponse>> Patch(string codemp, string codcon, string nrocon, int nroext, [FromBody] JsonPatchDocument patchDocument)
        {
            APIWiltelResponse response = new APIWiltelResponse { };

            if (patchDocument == null)
            {
                throw new BusinessException("No se recibió cuerpo de la petición o el mismo tiene un formato incorrecto");       
            }

            var editablePaths = new List<string> { "/CvmcthEstact" };

            if (patchDocument.Operations.Any(operation => editablePaths.Contains(operation.path)))
            {
                return await Service.Patch(codemp, codcon, nrocon, nroext, patchDocument);
            }
            else
            {
                throw new BusinessException("Sólo se puede editar el estado del contrato.");
            }           

        }
    }
}
