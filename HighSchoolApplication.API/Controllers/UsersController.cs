using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HighSchoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IRepository<Users> _repository;
        public IUsersRepository _usersRepository;
        public IMapper _mapper;
        public ILogger<Users> _logger;

        public UsersController(IRepository<Users> repository, IUsersRepository usersRepository, IMapper mapper, ILogger<Users> logger)
        {
            _repository = repository;
            _usersRepository = usersRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("StudentsList")]
        public Message<IEnumerable<UsersModel>> GetStudents()
        {
            try
            {
                var data = _usersRepository.GetActiveStudents();
                var studentsList = _mapper.Map<IEnumerable<UsersModel>>(data);

                return new Message<IEnumerable<UsersModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = studentsList
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on Getting students", ex);
                return new Message<IEnumerable<UsersModel>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("UsersList")]
        public Message<IEnumerable<UsersModel>> GetAllUsers()
        {
            try
            {
                var data = _repository.GetAll();
                var usersList = _mapper.Map<IEnumerable<UsersModel>>(data);

                return new Message<IEnumerable<UsersModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = usersList
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on Getting users", ex);
                return new Message<IEnumerable<UsersModel>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("UsersByClass/{ClassId}")]
        public async Task<Message<IEnumerable<sp_GetUsersByClassModel>>> GetUsersByClass(int ClassId)
        {
            try
            {
                var classUsers = await _usersRepository.GetUsersByClass(ClassId);
                var classUsersList = _mapper.Map<IEnumerable<sp_GetUsersByClassModel>>(classUsers);

                return new Message<IEnumerable<sp_GetUsersByClassModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = classUsersList
                };
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on geting users", ex);

                return new Message<IEnumerable<sp_GetUsersByClassModel>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 503,
                    Data = null
                };
            }
        }
    }
}