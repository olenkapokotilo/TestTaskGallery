using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TestTaskGallery.MVC.CompositionRoot;
using Unity.Mvc5;

namespace TestTaskGallery.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<TestTaskGallery.Core.Repositories.IUploadFileRepository, TestTaskGallery.DataAccess.Repositories.UploadFileRepository>();

            //DependencyResolver.SetResolver(new TestTaskGalleryUnitDependencyResolver(container));
            
           DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}