using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Models
{
    public class RespAnular
    {
        public int Estado { get; set; }


        public override string ToString()
        {
            return String.Format($"Estado: {Estado}");
        }
    }
}
