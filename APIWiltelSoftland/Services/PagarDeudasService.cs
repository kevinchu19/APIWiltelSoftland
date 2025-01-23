using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;

namespace APIWiltelSoftland.Services
{
    public class PagarDeudasService: Service
    {
        protected new PagarDeudasRepository Repository { get; }

        public PagarDeudasService(PagarDeudasRepository repository, Serilog.ILogger logger): base(repository, logger)
        {
            Repository = repository;
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

            string comprobantePagoDuplicado = await Repository.RecuperarEquivalencia("WEBSER", "PAGDUP", CodEnte);

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


            if (comprobanteDeuda.Saldo == 0 && comprobantePagoDuplicado=="")  //KT 22/1/2025 ID 275: No se valida mas si la entidad acepta pago duplicado
            {
                response.Estado = 7; // La deuda ya fue cancelada
                response.NroOperacion = "";
                Logger.Warning($"La deuda ya fue cancelada - Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}");
                return response;
            }

            if (comprobanteDeuda.Saldo < Convert.ToDecimal(Importe) && comprobantePagoDuplicado == "")  //KT 22/1/2025 ID 275: No se valida mas si la entidad acepta pago duplicado
            {
                response.Estado = 10; //El importe no puede ser superior al monto adeudado del comprobante
                response.NroOperacion = "";
                Logger.Warning($"El importe no puede ser superior al monto adeudado del comprobante - " +
                    $"Codfor: {comprobanteDeuda.Codfor}, Nrofor: {comprobanteDeuda.Nrofor}" +
                    $"Monto adeudado:{comprobanteDeuda.Saldo}, Importe pagado: {Importe}");
                return response;
            }

            if (response.Estado == 0)
            {

                response = await Repository.Post(CodBoca, CodTerminal,
                                                comprobanteDeuda, CodEnte,
                                                IdTransaccion, Importe, response.Estado, comprobanteDeuda.Saldo, comprobantePagoDuplicado);


            }


            return response;

        }


    }
}
