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
using TestTaskGallery.Core.Repositories;

namespace TestTaskGallery.API.Controllers
{
    public class ValuesController : ApiController
    {
        private IUserRepository _userRepository;
        private IUploadFileRepository _uploadFileRepository;

        private IMapper _mapper = null;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null) _mapper = MapperConfig.GetConfiguration().CreateMapper();
                return _mapper;
            }
        }
        public ValuesController(IUserRepository userRepository, IUploadFileRepository uploadFileRepository)
        {
            _userRepository = userRepository;
            _uploadFileRepository = uploadFileRepository;
        }
        // GET api/values
        [Route("api/users")]
        public IEnumerable<Core.Entities.User> Get()
        {
            var res = _userRepository.GetAllUsers();
            return res;
        }



        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public async Task<IEnumerable<UploadFileModel>> Post()
        {
            var list = new List<UploadFileModel>();
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            foreach (var file in HttpContext.Current.Request.Files.AllKeys)
            {
                var httpPostedFile = HttpContext.Current.Request.Files[file];
                byte[] file2 = new byte[httpPostedFile.InputStream.Length];
                await httpPostedFile.InputStream.ReadAsync(file2, 0, (int)httpPostedFile.InputStream.Length);


                var upfile = new UploadFileModel { Photo = file2, UserId = 1 };
                var result = _uploadFileRepository.SaveFile(Mapper.Map<Core.Entities.UploadFile>(upfile));
                list.Add(Mapper.Map<UploadFileModel>(result));
            }
            
            return list;
            
            
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
            _uploadFileRepository.DeleteFile(id);
        }
    }
}
