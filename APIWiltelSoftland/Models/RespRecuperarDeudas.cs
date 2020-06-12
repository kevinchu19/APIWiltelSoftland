using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Models
{
    public class RespRecuperarDeudas
    {
        public int Estado { get; set; }
        public List<Deudas> Deudas { get; set; }

        public override string ToString()
        {
            int count = 0;
            if (Deudas != null)
            {
                count = Deudas.Count();
            }
            return String.Format($"Estado: {Estado}, Cantidad de comprobantes:{count}");
        }
    }
}
