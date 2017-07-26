using AutoMapper;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace TestTaskGallery.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<Core.Repositories.IUploadFileRepository, DataAccess.Repositories.UploadFileRepository>();
            container.RegisterType<Core.Repositories.IUserRepository, DataAccess.Repositories.UserRepository>();
            container.RegisterType<Core.Services.Interfaces.IUploadFileService, Core.Services.UploadFileService>();
            container.RegisterType<Core.Services.Interfaces.IFileSystemPathService, Core.Services.FileSystemPathService>();
        }
    }
}