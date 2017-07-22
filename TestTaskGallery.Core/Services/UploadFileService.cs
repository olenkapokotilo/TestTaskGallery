using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Result SavePicture(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
