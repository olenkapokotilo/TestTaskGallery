using System;
using System.Collections.Generic;
using System.IO;
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
        private string[] _allowedExtentions;
        private IUploadFileRepository _uploadFileRepository;
        private IFileSystemPathService _fileSystemPathService;

        public UploadFileService(IUploadFileRepository uploadFileRepository, IFileSystemPathService fileSystemPathService)
        {
            _uploadFileRepository = uploadFileRepository;
            _fileSystemPathService = fileSystemPathService;
            _allowedExtentions = new string[] { ".png", ".gif", ".jpg"};
        }

        public Result SavePicture(HttpPostedFileBase httpPostedFile, int usesrId)
        {
            if (!_allowedExtentions.Any(httpPostedFile.FileName.Contains))
                return new Result {Message = "Only picture allowed.", Status = "Error"};

            var name = _fileSystemPathService.GenerateUniqueFileName(httpPostedFile.FileName);
            
            var path = _fileSystemPathService.GetImageSavePath() + name;
            var uploudfile = new UploadFile { Name = name, UserId = usesrId };
            var photo = (UploadFile)_uploadFileRepository.SaveFile(uploudfile);
            try
            {
                httpPostedFile.SaveAs(path); 
            }
            catch (Exception e)
            {
                _uploadFileRepository.DeleteFile(name);
                return new Result { Message = "Error: ."+e.Message, Status = "Error"};
            }
           
            return new Result { Message = "Saved.", Status = "Success", Photo = (UploadFile)photo };
        }
    }
}
