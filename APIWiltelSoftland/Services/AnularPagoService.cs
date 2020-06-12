using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;

namespace APIWiltelSoftland.Services
{
    public class AnularPagoService:Service
    {
        public AnularPagoRepository Anularrepository { get; }
        public ConsultarEstadoTransaccionRepository Consultarrepository { get; }

        public AnularPagoService(AnularPagoRepository anularrepository, Serilog.ILogger logger, ConsultarEstadoTransaccionRepository consultarrepository):base(anularrepository, logger)
        {
            Anularrepository = anularrepository;
            Consultarrepository = consultarrepository;
        }

        public async Task<RespAnular> Post(string codBoca, string codTerminal, string idTransaccion)
        {
            RespAnular response = new RespAnular();
            RespEstadoTransaccion estadotransaccion = new RespEstadoTransaccion();

            estadotransaccion = await Consultarrepository.Get(codBoca, codTerminal, idTransaccion);

            response.Estado = estadotransaccion.Estado; 

            if (response.Estado != 300) //Si es 300, la transaccion nunca llego al ente
            {
                bool pagoanulado = await Anularrepository.ValidarPagoAnulado(idTransaccion);

                if (pagoanulado==true)
                {
                    response.Estado = 301; //Transaccion anulada previamente
                    Logger.Warning("Pago anulado previamente");
                }
                else
                {
                    string[] nrooperacion = estadotransaccion.NroOperacion.Split("|");
                    string codfor = nrooperacion[0];
                    int nrofor = Convert.ToInt32(nrooperacion[1]);
                    response = await Anularrepository.Post(codBoca, codTerminal, idTransaccion, codfor, nrofor);
                }
            }

            return response;
        }


    }
}

