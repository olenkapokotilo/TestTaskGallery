using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.Core.Services
{
    public class FileSystemPathService : IFileSystemPathService
    {

        const string path = "~/App_Data";
        public string GetImageSavePath()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath(path);
        }
    }
}
