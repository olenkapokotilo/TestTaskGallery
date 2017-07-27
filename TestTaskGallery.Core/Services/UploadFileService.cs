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
        private readonly string[] _allowedExtentions; //todo: pass as ctor parameter
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly IFileSystemPathService _fileSystemPathService;

        public UploadFileService(IUploadFileRepository uploadFileRepository, IFileSystemPathService fileSystemPathService)
        {
            _uploadFileRepository = uploadFileRepository;
            _fileSystemPathService = fileSystemPathService;
            _allowedExtentions = new[] { ".png", ".gif", ".jpg" };
        }

        public Result SavePicture(HttpPostedFileBase httpPostedFile, int usesrId)
        {
            if (!_allowedExtentions.Any(httpPostedFile.FileName.Contains))
                return new Result {Message = "Only picture allowed.", Status = "Error"};

            var name = _fileSystemPathService.GenerateUniqueFileName(httpPostedFile.FileName);
            
            var path = _fileSystemPathService.GetImageSavePath() + name;
            var uploudfile = new UploadFile { Name = name, UserId = usesrId };
            var photo = _uploadFileRepository.SaveFile(uploudfile);
            try
            {
                httpPostedFile.SaveAs(path); 
            }
            catch (Exception e)
            {
                _uploadFileRepository.DeleteFile(photo.Id);
                return new Result { Message = "Error: ."+e.Message, Status = "Error"};
            }
           
            return new Result { Message = "Saved.", Status = "Success", Photo = photo };
        }

        public Result DeletePicture(int id)
        {
            var file = _uploadFileRepository.Get(id);
            _uploadFileRepository.DeleteFile(id);
            var path = _fileSystemPathService.GetImageSavePath() + file.Name;
            
            File.Delete(path);
            
            return new Result { Message = "Deleted.", Status = "Success"};
        }
    }
}
