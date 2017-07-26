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
        UploadFile GetNameById(int id);

        object SaveFile(object file);

        object DeleteFile(object file);
    }
}
