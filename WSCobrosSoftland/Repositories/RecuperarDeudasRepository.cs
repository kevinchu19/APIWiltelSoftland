using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Entities;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Repositories
{
    public class RecuperarDeudasRepository
    {
        public WILTELContext Context { get; set; }
        private string Connectionstring { get; set; }

        public RecuperarDeudasRepository(WILTELContext context, IConfiguration configuration)
        {
            this.Context = context;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<List<DeudasDTO>> Getall()
        {
            //return await Context.Vtrmvc.ToListAsync();
            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("ALM_WS_RecuperarDeudas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nrocta", "0003310000"));
                    cmd.Parameters.Add(new SqlParameter("@IdentificadorDeuda", ""));

                    var response = new List<DeudasDTO>();

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;

                }
            }
        }

        private DeudasDTO MapToValue(SqlDataReader reader)
        {
            return new DeudasDTO()
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
