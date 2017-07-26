using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.Core.Services.Interfaces
{
    public interface IFileSystemPathService
    {
        string GetImageSavePath();
        string GenerateUniqueFileName(string fileName);
    }
}
