
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Models;

namespace WSCobrosSoftland.Repositories
{
    public class PagarDeudasRepository
    {
        public WILTELContext Context { get; set; }
        private string Connectionstring { get; set; }

        public PagarDeudasRepository(WILTELContext context, IConfiguration configuration)
        {
            this.Context = context;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<PagarDeudasDTO> Post (string CodBoca, string CodTerminal,
                                               string CodDeuda, string CodEnte,
                                               string IdTransaccion, string Importe)
        {

            SarVtrrch HeaderCobranza = new SarVtrrch
            {
                SarVtrrchIdenti = IdTransaccion,
                SarVtrrchStatus = "N",
                SarVtrrchCodcom = "RCER",
                SarVtrrchNrocta = CodEnte,
                SarVtrrchCodemp = "WILTEL2"//,
                //SarVtFecalt = DateTime.Now,
                //SarVtFecmod = DateTime.Now
            };

            Context.Add(HeaderCobranza);

            await Context.SaveChangesAsync();
            
            return new PagarDeudasDTO
            {
                Estado = 1,
                NroOperacion = "1"
            };
        }

    }
}
