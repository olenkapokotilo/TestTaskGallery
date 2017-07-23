using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestTaskGallery.Core.Entities;


namespace TestTaskGallery.Core.Services.Interfaces
{
    public interface IUploadFileService
    {
        Result SavePicture(HttpPostedFileBase file, int userId);
    }
}
