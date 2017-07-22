using Microsoft.Practices.Unity;
using System.Web.Http;
using TestTaskGallery.API.CompositionRoot;
using Unity.WebApi;

namespace TestTaskGallery.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<Core.Repositories.IUploadFileRepository, DataAccess.Repositories.UploadFileRepository>();
            container.RegisterType<Core.Repositories.IUserRepository, DataAccess.Repositories.UserRepository>();
            //container.RegisterType<Core.Services.Interfaces.IUploadFileService, TestTaskGallery.Core.Services.UploadFileService>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new TestTaskGalleryUnitDependencyResolverAPI(container);
        }
    }
}