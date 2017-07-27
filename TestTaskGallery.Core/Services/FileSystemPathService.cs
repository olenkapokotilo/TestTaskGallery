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

        const string path = "~/App_Data"; //todo move to unity config, pass into constructor parameter
        public string GetImageSavePath()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath(path);
        }

        /// <summary>
        /// Generates unique fileName to prevent errors while saving files with the same names from different users
        /// </summary>
        /// <param name="fileName"></param>
        public string GenerateUniqueFileName(string fileName)
        {
            return Guid.NewGuid() + "_" + fileName;
        }
    }
}
