﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Models;

namespace APIWiltelSoftland.Repositories
{
    public class AnularPagoRepository: Repository
    {
        public AnularPagoRepository (WILTELContext context, IConfiguration configuration, Serilog.ILogger logger, WILTELPagosContext contextPagos) : base(context, configuration, logger)
        {
            ContextPagos = contextPagos;
        }

        public WILTELPagosContext ContextPagos { get; }

        public async Task<RespAnular> Post(string codBoca, string codTerminal, string idTransaccion, string codfor, int nrofor)
        {
            RespAnular response = new RespAnular
            {
                Estado = 0
            };

            SarVtrrch HeaderCobranza = new SarVtrrch
            {
                SarVtrrchIdenti = "A" + idTransaccion,
                SarVtrrchStatus = "A",
                SarVtrrchCodcom = await RecuperarEquivalencia("WEBSER","ANUCOM",""),
                SarVtrrchNrocta = "",
                SarVtrrchCodemp = "WILTEL2",
                SarVtrrchModfor = "VT",
                SarVtrrchCodfor = codfor,
                SarVtrrchNrofor = nrofor,
                SarVtrrchFchmov = DateTime.Now.Date,
                SarVtFecalt = DateTime.Now,
                SarVtFecmod = DateTime.Now,
                SarVtDebaja = "N",
                SarVtOalias = "SAR_VTRRCH",
                SarVtrrchErrmsg = "",
                SarVtUltopr = "A",
                SarVtUserid = "WEBAPI",
                UsrVtrrchWsestad = 999,
                UsrVtrrchCodboc = codBoca,
                UsrVtrrchCodter = codTerminal
            };

            try
            {
                ContextPagos.SarVtrrch.Add(HeaderCobranza);
                await ContextPagos.SaveChangesAsync();
                //Logger.Information("Se insertó registro de anulación en tabla SAR_VTRRCH ");
            }
            catch (Exception error)
            {
                Logger.Fatal($"Error al insertar registro de anulacion en tabla SAR_VTRRCH :{error}");
                response.Estado = 999;
                return response;
            };

            response = await ProcesoAnulacion(HeaderCobranza);

            return response;
        }




        public async Task<bool> ValidarPagoAnulado (string idtransaccion)
        {

            SarVtrrch vtrrch = await ContextPagos.SarVtrrch.FindAsync("A" + idtransaccion);

            if (vtrrch != null)
            {
                Logger.Warning("El id de transaccion " + idtransaccion + " ya fue anulado anteriormente.");
                return true;
            }

            return false;


        }

        private async Task<RespAnular> ProcesoAnulacion(SarVtrrch HeaderCobranza)
        {
            RespAnular respuesta = new RespAnular();

            await InsertaCwJmSchedules("WSCOBR");

            //Para dejar tiempo a Softland a que procese el recibo
            //Thread.Sleep(10000);

            //Para recargar la entidad con los datos del recibo impactado en Softland.
            //await Context.Entry(HeaderCobranza).ReloadAsync();

            switch (HeaderCobranza.SarVtrrchStatus)
            {
                case "S":
                    Logger.Information($"La anulación se recibio, procesada ok por Softland");
                    respuesta.Estado = 0;
                    break;
                case "A":
                    Logger.Warning($"La anulación se recibio, pero Softland aún no la proceso, SAR_VTRRRCH_IDENTI = {HeaderCobranza.SarVtrrchIdenti}");
                    respuesta.Estado = 0;
                    break;
                case "E":
                    Logger.Warning($"La anulación se recibio, el procesamiento dio error: {HeaderCobranza.SarVtrrchErrmsg}");
                    respuesta.Estado = 999;
                    break;
                default:
                    respuesta.Estado = 999;
                    break;
            }
            return respuesta;
            
        }
    }
}
