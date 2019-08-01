using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API
{
    public static class SecurityExtensions
    {
        public static SigningCredentials ToIdentitySigningCredentials(this string jwtSecret)
        {
            var symmetricKey = jwtSecret.ToSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            return signingCredentials;
        }

        public static SymmetricSecurityKey ToSymmetricSecurityKey(this string jwtSecret)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        }
    }
}
