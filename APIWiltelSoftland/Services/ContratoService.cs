using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Helpers;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Services
{
    public class ContratoService: Service
    {
        protected new ContratoRepository Repository { get; }
        protected new Serilog.ILogger Logger { get; }

        public ContratoService(ContratoRepository repository, Serilog.ILogger logger) : base(repository, logger)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task Patch(string codemp, string codcon, string nrocon, int nroext, DateTime fechacierreot,
                                              JsonPatchDocument patchDocument)
        {
            Cvmcth contrato = await Repository.RecuperaContrato(codemp, codcon, nrocon, nroext);

            if (contrato is null)
            {
                throw new NotFoundException("Contrato inexistente");
            }

            object nuevoEstado = patchDocument.Operations[0].value;

            ResultadoPatchContrato resultadoPatch = await Repository.Patch(contrato, fechacierreot,nuevoEstado.ToString());

            if (resultadoPatch.actualizado == "N")
            {
                throw new BadRequestException(resultadoPatch.errmsg); 
            }
           
        }
    }
}
