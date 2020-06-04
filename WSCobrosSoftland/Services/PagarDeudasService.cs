using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Entities;
using WSCobrosSoftland.Models;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland.Services
{
    public class PagarDeudasService: Service
    {
        protected new PagarDeudasRepository Repository { get; }
        protected new Serilog.ILogger Logger { get; }

        public PagarDeudasService(PagarDeudasRepository repository, Serilog.ILogger logger): base(repository, logger)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<RespPagarDeudas> Post(string CodBoca, string CodTerminal,
                                               string CodDeuda, string CodEnte,
                                               string IdTransaccion, string Importe)
        {
            RespPagarDeudas response = new RespPagarDeudas
            {
                Estado = 0,
                NroOperacion = ""
            };

            bool existe = await Repository.ExisteTransaccion(IdTransaccion);

            if (existe == true)
            {
                response.Estado = 999; //Error interno... la transaccion ya existe
                response.NroOperacion = "";
                Logger.Warning($"El id transaccion {IdTransaccion} ya fue recibido.");
                return response;
            }


            ComprobanteDeudaSoftland comprobanteDeuda = await Repository.RecuperarComprobanteDeuda(CodDeuda);

            if (comprobanteDeuda.Codfor == null)
            {
                response.Estado = 4; // Codigo de Deuda inexistente
                response.NroOperacion = "";
                Logger.Warning($"Codigo de Deuda inexistente, Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
                return response;
            }

            //A pedido de Diego Ballario, se elimina este control (Mail 29/05/2020)
            //if (comprobanteDeuda.Fchvnc.Date < DateTime.Now.Date)
            //{
            //    response.Estado = 3; //Deuda vencida
            //    response.NroOperacion = "";
            //    Logger.Warning($"Deuda vencida, el día {comprobanteDeuda.Fchvnc.Date} - Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
            //    return response;
            //}

            if (comprobanteDeuda.Saldo == 0)
            {
                response.Estado = 7; // La deuda ya fue cancelada
                response.NroOperacion = "";
                Logger.Warning($"La deuda ya fue cancelada - Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
                return response;
            }

            if (comprobanteDeuda.Saldo < Convert.ToDecimal(Importe))
            {
                response.Estado = 10; //El importe no puede ser superior al monto adeudado del comprobante
                response.NroOperacion = "";
                Logger.Warning($"El importe no puede ser superior al monto adeudado del comprobante - " +
                    $"Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}" +
                    $"Monto adeudado:{comprobanteDeuda.Saldo}, Importe pagado: {Importe}");
                return response;
            }

            if (response.Estado != 999)
            {

                response = await Repository.Post(CodBoca, CodTerminal,
                                                comprobanteDeuda, CodEnte,
                                                IdTransaccion, Importe, response.Estado);


            }


            return response;

        }


    }
}
