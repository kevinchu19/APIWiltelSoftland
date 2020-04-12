using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCobrosSoftland.Models
{
    public class RespRecuperarDeudas
    {
        public int Estado { get; set; }
        public List<Deudas> Deudas { get; set; }
    }
}
