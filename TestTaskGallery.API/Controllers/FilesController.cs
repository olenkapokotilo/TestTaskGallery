using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestTaskGallery.Core.Entities;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.API.Controllers
{
    [RoutePrefix("api/users/{userId:int}/files")]
    public class FilesController : ApiController
    {
        private readonly IUploadFileService _uploadFileService;
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly IFileSystemPathService _fileSystemPathService;

       public FilesController(IUploadFileService uploadFileService, IUploadFileRepository uploadFileRepository, IFileSystemPathService fileSystemPathService)
        {
            _uploadFileService = uploadFileService;
            _uploadFileRepository = uploadFileRepository;
            _fileSystemPathService = fileSystemPathService;
        }

        [Route("{fileId:int}")]
       public HttpResponseMessage Get(int fileId)
        {
            var file = _uploadFileRepository.Get(fileId);
            var path = _fileSystemPathService.GetImageSavePath() + file.Name;
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(File.ReadAllBytes(path))
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/*");
            return result;
        }
        
        [Route("")]
        public Result Post(int userId)
        {
            var httpPostedFile = HttpContext.Current.Request.Files["file"]; // ? "file" const
            var result = _uploadFileService.SavePicture(new HttpPostedFileWrapper(httpPostedFile), userId);//TODO: if status error
            return result;
        }

        [Route("{id:int}")]
        public void Delete(int id)
        {
            _uploadFileService.DeletePicture(id);//TODO: return Result
        }
    }
}
