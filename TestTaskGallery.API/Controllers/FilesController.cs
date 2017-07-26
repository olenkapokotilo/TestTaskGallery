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
using TestTaskGallery.Core.Entities;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.API.Controllers
{
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

        [Route("api/files")]
        [HttpGet]
        public byte[] Get(int fileId)
        {
            var file = _uploadFileRepository.GetNameById(fileId);
            var path = _fileSystemPathService.GetImageSavePath() + file.Name;
            var result = File.ReadAllBytes(path);
            return result;
        }

        [Route("api/addFile")]
        [HttpPost]
        public Result Post()
        {
            var httpPostedFile = HttpContext.Current.Request.Files["file"]; // ? "file" const
            var result = _uploadFileService.SavePicture(new HttpPostedFileWrapper(httpPostedFile), 1);//TODO: not static userId
            return result;
        }
           
        [Route("api/deletePhoto")]
        [HttpDelete]
        public void PhotoDelete(string fileName)
        {
            _uploadFileRepository.DeleteFile(fileName);
        }
    }
}
