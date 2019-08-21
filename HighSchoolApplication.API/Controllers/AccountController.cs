using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Utils;
using HighSchoolApplication.Data;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HighSchoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Users> _repository;

        public AccountController(IUsersRepository usersRepository, IMapper mapper, IConfiguration config, IRepository<Users> repository)
        {
            _repository = repository;
            _config = config;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel login)
        {
            IActionResult response = null;
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UsersModel userInfo)
        {

            var jwtSecurityToken = new JwtSecurityToken
           (
               issuer: _config["Tokens:Issuer"],
               audience: _config["Tokens:Audience"],
               claims: CreateClaims(userInfo),
               expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
               signingCredentials: _config["Tokens:Key"].ToIdentitySigningCredentials()
           );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private IEnumerable<Claim> CreateClaims(UsersModel userInfo)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return claims;
        }

        private UsersModel AuthenticateUser(LoginModel login)
        {
            //Users userEntity = _usersRepository.GetActiveUserByUsername(login.Username);

            UsersModel user = new UsersModel();

            //if (userEntity != null)
            //{
            //    if (string.Compare(Helper.Hash(login.Password), userEntity.Password) == 0)
            //    {
            //        user = _mapper.Map<UsersModel>(userEntity);
            //    }
            //}

            user.Username = "ldyrmishi";
            user.Email = "lediodyrmishi@yahoo.com";

            return user;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public void Register([FromBody] UsersModel usersModel)
        {
            usersModel.Password = Helper.Hash(usersModel.Password);
            usersModel.ConfirmPassword = Helper.Hash(usersModel.ConfirmPassword);

            Users usersEntity = _mapper.Map<Users>(usersModel);

            _repository.Insert(usersEntity);
            _repository.Save();
        }
        


    }
}