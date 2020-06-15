using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Models;
using APIWiltelSoftland.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIWiltelSoftland.Services
{
    public class APIWiltelLoginService : Service, IJwtLoginManager
    {
        public new APIWiltelLoginRepository Repository { get; }
        public Serilog.ILogger logger { get; }
        public IConfiguration Configuration { get; }

        private List<UsrWstush> usuarios = new List<UsrWstush>();
        
        public APIWiltelLoginService(APIWiltelLoginRepository repository, Serilog.ILogger logger, 
                                        IConfiguration configuration) 
            :base(repository, logger)
        {
            Repository = repository;
            this.logger = logger;
            Configuration = configuration;
        }

        public async Task<string> LoginWithJwt(string usuario, string password)
        {
            var key = Configuration["key"];
            var usuarios = await Repository.RecuperaUsuarios();

            if (!usuarios.Any(u => u.UsrWstushUserid == usuario && u.UsrWstushUsrpwd == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            
        }
    }
}
