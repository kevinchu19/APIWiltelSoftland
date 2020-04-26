using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Repositories
{
    public class Repository
    {
        protected WILTELContext Context { get; }
        protected IConfiguration Configuration { get; }
        protected Serilog.ILogger Logger { get; }
        protected string Connectionstring { get; }

        public Repository(WILTELContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            Context = context;
            Configuration = configuration;
            Logger = logger;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        protected async Task InsertaCwJmSchedules(string codjob)
        {
            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("ALM_InsCwJmSchedules", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CODJOB", codjob));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    Logger.Information("Se insertó cwjmschedules");
                }
            }
        }

        protected async Task<string> RecuperarEquivalencia(string codigo, string codi01, string codi02)
        {
            string sSql = "SELECT " +
                " INTEQE_CODEQU " +
                " FROM INTEQE " +
                " WHERE " +
                $" INTEQE_CODIGO = '{codigo}' AND " +
                $" INTEQE_CODI01 = '{codi01}' AND " +
                $" INTEQE_CODI02 = '{codi02}' ";

            string response = "";

            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, sql))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = (string)reader["INTEQE_CODEQU"];
                        }
                    }
                }

                if (response == "")
                {
                    Logger.Warning($"No existe la equivalencia - Codigo origen 1: {codi01} - Codigo origen 2: {codi02}, para el registro {codigo}");
                }
                return response;
            }
        }

        public async Task<ComprobanteDeudaSoftland> RecuperarComprobanteDeuda(string identificadorDeuda)
        {
            string sSql = "SELECT " +
                " VTRMVH_CODEMP, VTRMVH_MODFOR, VTRMVH_CODFOR, VTRMVH_NROFOR, VTRMVC_FCHVNC, VTRMVC_IMPNAC, VTRMVH_NROCTA, " +
                " ISNULL((SELECT SUM(VTRMVC_IMPNAC) FROM VTRMVC " +
                " WHERE " +
                " VTRMVC_EMPAPL = VTRMVH_CODEMP AND " +
                " VTRMVC_MODAPL = VTRMVH_MODFOR AND " +
                " VTRMVC_CODAPL = VTRMVH_CODFOR AND " +
                " VTRMVC_NROAPL = VTRMVH_NROFOR ),0) SALDO " +
                " FROM VTRMVH " +
                " INNER JOIN VTRMVC ON " +
                " VTRMVC_CODEMP = VTRMVH_CODEMP AND " +
                " VTRMVC_MODFOR = VTRMVH_MODFOR AND " +
                " VTRMVC_CODFOR = VTRMVH_CODFOR AND " +
                " VTRMVC_NROFOR = VTRMVH_NROFOR AND " +
                " VTRMVC_CODFOR = VTRMVC_CODAPL " +
                " WHERE " +
                $" USR_VTRMVH_IDC = '{identificadorDeuda}' ";

            ComprobanteDeudaSoftland comprobante = new ComprobanteDeudaSoftland();

            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, sql))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            comprobante.Codemp = (string)reader["VTRMVH_CODEMP"];
                            comprobante.Modfor = (string)reader["VTRMVH_MODFOR"];
                            comprobante.Codfor = (string)reader["VTRMVH_CODFOR"];
                            comprobante.Nrofor = (int)reader["VTRMVH_NROFOR"];
                            comprobante.Fchvnc = (DateTime)reader["VTRMVC_FCHVNC"];
                            comprobante.Import = (decimal)reader["VTRMVC_IMPNAC"];
                            comprobante.Nrocta = (string)reader["VTRMVH_NROCTA"];
                            comprobante.Saldo = (decimal)reader["SALDO"];

                        }
                    }
                }

                return comprobante;
            }

        }


    }
}
