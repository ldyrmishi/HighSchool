using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Utils
{
    public class JWTConfiguration
    {
        public string Secret = "secretKey";
        //public string GenerateAccessToken(TokenViewModel model)
        //{
        //    var jwtSecurityToken = new JwtSecurityToken
        //    (
        //        issuer: "http://localhost/",
        //        audience: "http://localhost",
        //        claims: CreateClaims(model),
        //        expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
        //        signingCredentials: Secret.ToIdentitySigningCredentials()
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        //}

        //public TokenViewModel UserDataModel(string username)
        //{
        //    TokenViewModel model = new TokenViewModel();

        //    return model;
        //}

        //private IEnumerable<Claim> CreateClaims(TokenViewModel User)
        //{
        //    var claims = new List<Claim>
        //{
        //        new Claim("Id", User.IdUser.ToString()),
        //        new Claim("Name", User.Name),
        //        new Claim("Surname", User.Surname),
        //        new Claim("Username", User.UserName),
        //        new Claim("Role", User.Roli),
        //        new Claim("IdRoli",User.IdRoli.ToString()),
        //        new Claim("Structure", User.StructureName),
        //        new Claim("StructureId", User.StructureId.ToString()),
        //        new Claim("IdInspectorate", User.IdInspectorate.ToString()),
        //        new Claim("StateInspectorateId", User.IdStateInspectorate.ToString()),
        //        new Claim("Groups", JsonConvert.SerializeObject(User.Groups)),
        //        new Claim("IsTest",User.IsTest.ToString()),
        //        new Claim("email",String.IsNullOrEmpty(User.email)? "": User.email),
        //        new Claim()

        //};

        //    return claims;
        //}
    }
}
