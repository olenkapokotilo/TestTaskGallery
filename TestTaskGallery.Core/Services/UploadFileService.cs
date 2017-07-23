using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestTaskGallery.Core.Entities;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.Core.Services
{
    public class UploadFileService : IUploadFileService
    {
        private IUploadFileRepository _uploadFileRepository;
        private IFileSystemPathService _fileSystemPathService;

        public UploadFileService(IUploadFileRepository uploadFileRepository, IFileSystemPathService fileSystemPathService)
        {
            _uploadFileRepository = uploadFileRepository;
            _fileSystemPathService = fileSystemPathService;
        }

        public Result SavePicture(HttpPostedFileBase httpPostedFile, int usesrId)
        {
            byte[] file2 = new byte[httpPostedFile.InputStream.Length];
            httpPostedFile.InputStream.Read(file2, 0, (int)httpPostedFile.InputStream.Length);
            //await httpPostedFile.InputStream.ReadAsync(file2, 0, (int)httpPostedFile.InputStream.Length);
            var upfile = new UploadFile { Photo = file2, UserId = 1 };
            _uploadFileRepository.SaveFile(upfile);
            return new Result { Message = "Only picture allowed.", Status = "Success" };
        }
    }
}
