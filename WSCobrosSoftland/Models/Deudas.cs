using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCobrosSoftland.Models
{
    public class Deudas
    {
        public string CodDeuda { get; set; }
        public string CodSubEnte { get; set; }
        public string Vencimiento { get; set; }
        public string Importe { get; set; }
        public string Descripcion { get; set; }
        public string ParSubCod{ get; set; }
    }
}
