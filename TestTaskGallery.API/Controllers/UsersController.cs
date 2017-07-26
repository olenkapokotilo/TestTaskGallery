using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using System.Web.Http;
using TestTaskGallery.API.Models;
using TestTaskGallery.Core;
using TestTaskGallery.Core.Repositories;

namespace TestTaskGallery.API.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;
       public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("api/users")]
        [HttpGet]
        public IEnumerable<Core.Entities.User> Get()
        {
            var res = _userRepository.GetAllUsers();
            return res;
        }

        [Route("api/addUser")]
        [HttpPost]
        public UserModel AddUserPost([FromBody]UserModel value)
        {
            var result = _userRepository.Add(Map.Mapper.Map<Core.Entities.User>(value));
            return Map.Mapper.Map<UserModel>(result);
        }
    }
}
