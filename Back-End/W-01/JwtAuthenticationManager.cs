using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CarFactory
{
    //bu classin gorevi ilgili kullanici eger dogrulanirsa kullniciya tokeni verir

    public class JwtAuthenticationManager : IJWTAuthenticaionManager
    {

        private readonly string _key;
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"dgpays","admin1" },
            {"dgpayit","admin2" },

        };
        public string Authentication(string username, string password)
        {
            //bir kullanici var mi ?
            if (!users.Any(x => x.Key == username && x.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            //token key 1byte olan jwt signature bolumunda olan mysecuritykeyishaere ilan parametre diyebiliriz.
            var tokenkey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.Now.AddHours(1),
                // Header Bolumu olusturma

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
