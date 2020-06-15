using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Entities;
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

        public async Task Patch(Cvmcth contrato, JsonPatchDocument patchDocument)
        {
            patchDocument.ApplyTo(contrato);
            await Context.SaveChangesAsync();           
        }

        public async Task ActualizaFechasNuevaExtension(Cvmcth contrato)
        {
            DateTime fechaCierreOT = DateTime.Now;
            DateTime primerDiaMes;
            DateTime ultimoDiaMes;
            DateTime ultfac;


            int extensionAnteriorFacturada = await VerificaExtensionAnteriorFacturadaAsync(contrato, fechaCierreOT);


            if (extensionAnteriorFacturada > 0) 
            {
                //Comienza el primer dia del mes siguiente
                primerDiaMes = new DateTime(fechaCierreOT.Year, fechaCierreOT.Month, 1).AddMonths(1);
                ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
                ultfac = ultimoDiaMes.AddYears(50);
            }
            else
            {
                //Comienza este mes
                primerDiaMes = new DateTime(fechaCierreOT.Year, fechaCierreOT.Month, 1);
                ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
                ultfac = ultimoDiaMes.AddYears(50);
            }


            contrato.CvmcthFchmov = fechaCierreOT; ;
            contrato.CvmcthFacdes = primerDiaMes;
            contrato.CvmcthFachas = ultimoDiaMes;
            contrato.CvmcthPrifac = primerDiaMes;
            contrato.CvmcthUltfac = ultfac;
            contrato.UsrCvmcthFcfinot = fechaCierreOT;

            await Context.SaveChangesAsync();
                                   
        }

        public async Task ActualizaFechasCierreExtension(Cvmcth contrato)
        {
            DateTime fechaCierreOT = DateTime.Now;
            DateTime ultimoDiaMes;
            DateTime ultfac;


            int extensionFacturada = await VerificaExtensionFacturadaAsync(contrato, fechaCierreOT);

           
            if (extensionFacturada>0)
            {
                //Ultima factura se hace este mes
                ultimoDiaMes = new DateTime(fechaCierreOT.Year, fechaCierreOT.Month, 1).AddMonths(1).AddDays(-1);
                ultfac = ultimoDiaMes;
            }
            else
            {
                //Ultima factura se hizo el mes pasado
                ultimoDiaMes = new DateTime(fechaCierreOT.Year, fechaCierreOT.Month, 1).AddDays(-1);
                ultfac = ultimoDiaMes;
            }

            contrato.CvmcthFchmov = fechaCierreOT;
            contrato.CvmcthFachas = ultimoDiaMes;
            contrato.CvmcthUltfac = ultfac;
            contrato.UsrCvmcthFcfinot = fechaCierreOT;

            await Context.SaveChangesAsync();

        }

        private async Task<int> VerificaExtensionFacturadaAsync (Cvmcth contrato, DateTime fechaCierreOT)
        {
            DateTime primerDiaMes = new DateTime(fechaCierreOT.Year, fechaCierreOT.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
            

            string sSql = "SELECT " +
                " COUNT(*) CANTIDAD " +
                " FROM VTRMVH " +
                " INNER JOIN VTRMVI ON" +
                " VTRMVI_CODEMP = VTRMVH_CODEMP AND " +
                " VTRMVI_MODFOR = VTRMVH_MODFOR AND " +
                " VTRMVI_CODFOR = VTRMVH_CODFOR AND " +
                " VTRMVI_NROFOR = VTRMVH_NROFOR " +
                " WHERE " +
                $" VTRMVI_EMPCON = '{contrato.CvmcthCodemp}' AND" +
                $" VTRMVI_CODCON = '{contrato.CvmcthCodcon}' AND" +
                $" VTRMVI_NROCON = '{contrato.CvmcthNrocon}' AND" +
                $" VTRMVI_NROEXT = '{contrato.CvmcthNroext}' AND " +
                $" VTRMVH_FCHMOV BETWEEN '{primerDiaMes.ToString("yyyyMMdd")}' AND '{ultimoDiaMes.ToString("yyyyMMdd")}' ";

            int cantidad = 0;

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
                            cantidad = (int)reader["CANTIDAD"];              
                        }
                    }
                }

                return cantidad;
            }
        }

        private async Task<int> VerificaExtensionAnteriorFacturadaAsync(Cvmcth contrato, DateTime fechaCierreOT)
        {
            DateTime primerDiaMes = new DateTime(fechaCierreOT.Year, fechaCierreOT.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
            
            string sSql = "SELECT " +
                " COUNT(*) CANTIDAD " +
                " FROM VTRMVH " +
                " INNER JOIN VTRMVI ON" +
                " VTRMVI_CODEMP = VTRMVH_CODEMP AND " +
                " VTRMVI_MODFOR = VTRMVH_MODFOR AND " +
                " VTRMVI_CODFOR = VTRMVH_CODFOR AND " +
                " VTRMVI_NROFOR = VTRMVH_NROFOR " +
                " WHERE " +
                $" VTRMVI_EMPCON = '{contrato.CvmcthCodemp}' AND" +
                $" VTRMVI_CODCON = '{contrato.CvmcthCodcon}' AND" +
                $" VTRMVI_NROCON = '{contrato.CvmcthNrocon}' AND" +
                $" VTRMVI_NROEXT = '{contrato.CvmcthNroext-1}' AND " +
                $" VTRMVH_FCHMOV BETWEEN '{primerDiaMes.ToString("yyyyMMdd")}' AND '{ultimoDiaMes.ToString("yyyyMMdd")}' ";

            int cantidad = 0;

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
                            cantidad = (int)reader["CANTIDAD"];
                        }
                    }
                }

                return cantidad;
            }
        }

    }

}
