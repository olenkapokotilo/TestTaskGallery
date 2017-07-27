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
    //todo : routing
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
            var res = _userRepository.GetAll();
            return res;
        }

        [Route("api/addUser")]
        [HttpPost]

        //todo: rename to Post or AddUser
        public UserModel AddUserPost([FromBody]UserModel value) //todo: return Core model, Post WebModel
        {
            var result = _userRepository.Add(Map.Mapper.Map<Core.Entities.User>(value));
            return Map.Mapper.Map<UserModel>(result);
        }
    }
}
