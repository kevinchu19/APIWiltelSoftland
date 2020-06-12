using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;
using APIWiltelSoftland.Services;
using AutoMapper;
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
    [Route("api/[controller]")]
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
        public async Task<ActionResult<PatchContratoResponse>> Patch(string codemp, string codcon, string nrocon, int nroext, [FromBody] JsonPatchDocument patchDocument)
        {
            PatchContratoResponse response = new PatchContratoResponse { };

            if (patchDocument == null)
            {
                return BadRequest();                
            }

            var editablePaths = new List<string> { "/CvmcthEstact" };

            if (patchDocument.Operations.Any(operation => editablePaths.Contains(operation.path)))
            {
                return await Service.Patch(codemp, codcon, nrocon, nroext, patchDocument);
            }
            else
            {
                response.mensaje = "Sólo se puede editar el estado del contrato.";
                return BadRequest(response);
            }



            

        }
    }
}
