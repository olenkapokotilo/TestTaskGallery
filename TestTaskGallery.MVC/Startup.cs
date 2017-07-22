using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestTaskGallery.MVC.Startup))]
namespace TestTaskGallery.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
