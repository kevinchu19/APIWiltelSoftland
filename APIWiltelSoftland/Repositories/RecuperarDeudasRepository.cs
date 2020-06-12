
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Models;

namespace APIWiltelSoftland.Repositories
{
    public class RecuperarDeudasRepository: Repository
    {
        public RecuperarDeudasRepository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger): base(context, configuration, logger)
        {
        }
        
        public async Task<List<Deudas>> GetDeudas(string codEnte, string clave, string valor)
        {
            List<Deudas> deudas = new List<Deudas>();

            
            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("ALM_WS_RecuperarDeudas", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CodEnte", codEnte));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));
                    cmd.Parameters.Add(new SqlParameter("@Valor", valor.ToString()));

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            deudas.Add(MapToValue(reader));
                        }
                    }
                }
            }

            return deudas;
           
        }

        private Deudas MapToValue(SqlDataReader reader)
        {
            return new Deudas()
            {
                CodDeuda = (string)reader["CodDeuda"],
                CodSubEnte = (string)reader["CodSubEnte"],
                Vencimiento = (string)reader["Vencimiento"],
                Importe = (string)reader["Importe"],
                Descripcion = (string)reader["Descripcion"],
                ParSubCod = (string)reader["ParSubCod"]

            };
        }
        
    }
}
