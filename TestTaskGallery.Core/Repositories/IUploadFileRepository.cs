using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskGallery.Core.Entities;

namespace TestTaskGallery.Core.Repositories
{
    public interface IUploadFileRepository
    {
        UploadFile Get(int id);

        UploadFile SaveFile(UploadFile file);

        void DeleteFile(int id);
    }
}
