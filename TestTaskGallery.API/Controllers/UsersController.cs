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
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;
       public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("")]
       public IEnumerable<UserModel> Get()
        {
            return  Map.Mapper.Map<IEnumerable<UserModel>>(_userRepository.GetAll());
        }

        [Route("")]
        public UserModel Post([FromBody]UserModel value)
        {
            var result = _userRepository.Add(Map.Mapper.Map<Core.Entities.User>(value));
            return Map.Mapper.Map<UserModel>(result);
        }
    }
}
