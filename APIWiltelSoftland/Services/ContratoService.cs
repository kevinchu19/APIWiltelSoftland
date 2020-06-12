using APIWiltelSoftland.Entities;
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

        public async Task<ActionResult> Patch(string codemp, string codcon, string nrocon, int nroext,
                                              JsonPatchDocument patchDocument)
        {
            var resultBadRequest = new BadRequestResult();
            var resultOk = new OkResult();

            Cvmcth contrato = await Repository.RecuperaContrato(codemp, codcon, nrocon, nroext);

            if (contrato is null)
            {
                var resultNotFound = new NotFoundResult();
                return resultNotFound;
            }

            object nuevoEstado = patchDocument.Operations[0].value;

            switch (contrato.CvmcthEstact)
            {
                case "00":
                    switch (nuevoEstado)
                    {
                        case "03":
                            if (contrato.UsrCvmcthModifi == "S")
                            {
                                //El contrato se encuentra modificado, no puede actualizar el estado.
                                return resultBadRequest;
                            }
                            break;
                        default:
                            return resultBadRequest;
                    }
                    break;
                case "02":
                    switch (nuevoEstado)
                    {
                        case "06": //Stand by
                            await Repository.Patch(contrato, patchDocument);
                            await Repository.ActualizaFechasCierreExtension(contrato);
                            break;
                        default:
                            return resultBadRequest;
                    }
                    break;

                case "03":
                    switch (nuevoEstado)
                    {
                        case "02": //Habilitado para liquidar y facturar
                            await Repository.Patch(contrato, patchDocument);
                            await Repository.ActualizaFechasNuevaExtension(contrato);
                            break;
                        case "08": //Standby
                            break;
                        default:
                            return resultBadRequest;
                    }
                    break;

                case "05":
                    switch (nuevoEstado)
                    {
                        case "09": //Stand By
                            await Repository.Patch(contrato, patchDocument);
                            break;
                        default:
                            return resultBadRequest;
                    }
                    break;

                case "07":
                    switch (nuevoEstado)
                    {
                        case "10": //Stand By
                            await Repository.Patch(contrato, patchDocument);
                            break;
                        default:
                            return resultBadRequest;
                    }
                    break;

                default:
                    //Ninguna de las combinaciones esperadas
                    return resultBadRequest;
            }

            return resultOk;
        }
    }
}
