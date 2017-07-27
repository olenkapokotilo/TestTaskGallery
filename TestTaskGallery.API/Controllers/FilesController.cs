using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestTaskGallery.Core.Entities;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.API.Controllers
{
    //TODO: use proper REST routings

    [RoutePrefix("api/files")]
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

        //[Route("{fileId:int}")]    api/Files/12
        [Route("")]
        public byte[] Get(int fileId)
        {
            //https://stackoverflow.com/questions/12467546/is-there-a-recommended-way-to-return-an-image-using-asp-net-web-apihttps://stackoverflow.com/questions/12467546/is-there-a-recommended-way-to-return-an-image-using-asp-net-web-api
            var file = _uploadFileRepository.Get(fileId);
            var path = _fileSystemPathService.GetImageSavePath() + file.Name;
            var result = File.ReadAllBytes(path);
            return result;
        }
        
        [Route("")]
        public Result Post()
        {
            var httpPostedFile = HttpContext.Current.Request.Files["file"]; // ? "file" const
            var result = _uploadFileService.SavePicture(new HttpPostedFileWrapper(httpPostedFile), 1);//TODO: not static userId
            return result;
        }

        [Route("{id:int}")]
        public void Delete(int id)
        {
            //todo: 3. delete file from file system by name (implement method in service)
            //4. wrap this in service
            _uploadFileRepository.DeleteFile(id);
        }
    }
}
