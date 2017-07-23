using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using TestTaskGallery.API.Mapper;
using TestTaskGallery.API.Models;
using TestTaskGallery.Core.Entities;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.API.Controllers
{
    public class ValuesController : ApiController
    {
        private IUploadFileService _uploadFileService;
        private IUserRepository _userRepository;

        private IMapper _mapper = null;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null) _mapper = MapperConfig.GetConfiguration().CreateMapper();
                return _mapper;
            }
        }
        public ValuesController(IUploadFileService uploadFileService, IUserRepository userRepository)
        {
            _uploadFileService = uploadFileService;
            _userRepository = userRepository;
        }
        // GET api/values
        [Route("api/users")]
        public IEnumerable<Core.Entities.User> Get()
        {
            var res = _userRepository.GetAllUsers();
            return res;
        }

        // POST api/values
        public Result Post()
        {
                var httpPostedFile = HttpContext.Current.Request.Files["file"];
                var result = _uploadFileService.SavePicture(new HttpPostedFileWrapper(httpPostedFile), 1);
            return result;
        }
           
        // PUT api/values/5
        [Route("api/addUser")]
        [HttpPost]
        public UserModel AddUserPost([FromBody]UserModel value)
        {
            var result = _userRepository.Add(Mapper.Map<Core.Entities.User>(value));
            return Mapper.Map<UserModel>(result);
        }

        // DELETE api/values/5
        [Route("api/deletePhoto")]
        [HttpDelete]
        public void PhotoDelete(int id)
        {
            //_uploadFileRepository.DeleteFile(id);
        }
    }
}
