﻿using AutoMapper;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Utils;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        private readonly ILogger<Users> _logger;

        public AccountController(IUsersRepository usersRepository, IMapper mapper, IConfiguration config, IRepository<Users> repository, ILogger<Users> logger)
        {
            _repository = repository;
            _config = config;
            _usersRepository = usersRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public Message<LoginModel> Login([FromBody]LoginModel login)
        {
            var user = AuthenticateUser(login);

            var response = new Message<LoginModel>();

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                login.Token = tokenString;

                response.IsSuccess = true;
                response.StatusCode = 200;
                response.ReturnMessage = "OK";
                response.Data = login;
                
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
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Role", userInfo.Role.RoleDescription),
                new Claim("IdUser", Convert.ToString(userInfo.Id))
            };

            return claims;
        }

        private UsersModel AuthenticateUser(LoginModel login)
        {
            Users userEntity = _usersRepository.GetActiveUserByUsername(login.Username);

            UsersModel user = new UsersModel();

            if (userEntity != null)
            {
                if (string.Compare(Helper.Hash(login.Password), userEntity.Password) == 0)
                {
                    user = _mapper.Map<UsersModel>(userEntity);
                }
            }

            return user;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public Message<UsersModel> Register([FromBody] UsersModel usersModel)
        {
            try
            {
                usersModel.Password = Helper.Hash(usersModel.Password);
                usersModel.ConfirmPassword = Helper.Hash(usersModel.ConfirmPassword);

                Users usersEntity = _mapper.Map<Users>(usersModel);

                _repository.Insert(usersEntity);
                _repository.Save();

                return new Message<UsersModel>()
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    ReturnMessage = "Data inserted succesfully",
                    Data = usersModel
                };
            }
            catch(Exception ex)
            {
                _logger.LogError("Save user error",ex);
                return new Message<UsersModel>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = usersModel
                };
            }
        }
    }
}