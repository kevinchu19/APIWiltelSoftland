using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
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

        
        public async Task<RespRecuperarDeudas> Getall(string codEnte, string clave, string valor)
        {
            int estado = 0;
            List<Deudas> response = new List<Deudas>();

            try
            {
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
                                response.Add(MapToValue(reader));
                            }
                        }
                    }
                }

                if (response.Count == 0)
                {
                    estado = 1; //No se han encontrado pendientes para la identificacion ingresada
                }


            }
            catch (Exception mensajeError)
            {
                estado = 201;
            }

            
            return new RespRecuperarDeudas
            {
                Estado = estado,
                Deudas = response
            };
            //return await Context.Vtrmvc.ToListAsync();
            
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
