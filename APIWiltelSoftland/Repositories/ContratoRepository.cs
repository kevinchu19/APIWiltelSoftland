using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

using System.Threading.Tasks;

namespace APIWiltelSoftland.Repositories
{
    public class ContratoRepository : Repository
    {
        public ContratoRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger) : base(context, configuration, logger)
        {
        }

        public async Task<Cvmcth> RecuperaContrato(string codemp, string codcon, string nrocon, int nroext){
            return await Context.Cvmcth.FirstOrDefaultAsync(contrato => contrato.CvmcthCodemp.Trim() == codemp.Trim() &&
                                                             contrato.CvmcthCodcon.Trim() == codcon.Trim() &&
                                                             contrato.CvmcthNrocon.Trim() == nrocon.Trim() &&
                                                             contrato.CvmcthNroext == nroext);
        }

        public async Task<ResultadoPatchContrato> Patch(Cvmcth contrato, DateTime fechacierreot,string nuevoEstado)
        {
            string actualizado = "N";
            string errmsg = "";
            

            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("ALM_WS_CambioEstadoContrato", sql))
                {
                    

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Codemp", contrato.CvmcthCodemp));
                    cmd.Parameters.Add(new SqlParameter("@Codcon", contrato.CvmcthCodcon));
                    cmd.Parameters.Add(new SqlParameter("@Nrocon", contrato.CvmcthNrocon));
                    cmd.Parameters.Add(new SqlParameter("@Nroext", contrato.CvmcthNroext));
                    cmd.Parameters.Add(new SqlParameter("@FchcieOT", fechacierreot));
                    cmd.Parameters.Add(new SqlParameter("@NewEst", nuevoEstado));

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            actualizado = (string)reader["actualizado"];
                            errmsg = (string)reader["errmsg"];
                        }
                    }
                }
            }

            ResultadoPatchContrato resultado = new ResultadoPatchContrato();
            resultado.actualizado = actualizado;
            resultado.errmsg = errmsg;
            return resultado;
                 
        } 
    }

}
