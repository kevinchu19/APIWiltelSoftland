using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Models
{
    public interface IJwtLoginManager
    {

        Task<string> LoginWithJwt(string usuario, string password);
    }
}
