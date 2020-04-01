using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCobrosSoftland.Models
{
    public class RecuperarDeudasDTO
    {
        public int Estado { get; set; }
        public List<DeudasDTO> ListaDeudas { get; set; }
    }
}
