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
        object SaveFile(UploadFile file);
        object DeleteFile(object file);


        IEnumerable<User> Start();
    }
}
