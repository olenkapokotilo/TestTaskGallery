using System.Web;
using System.Web.Optimization;

namespace TestTaskGallery.API
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                     "~/Scripts//app/lib/angular.js",
                     "~/Scripts/app/lib/angular-route.js",
                     "~/Scripts/app/lib/angular-file-saver.bundle.js",
                     "~/Scripts/app/lib/FileSaver.js",
                     "~/Scripts/app/lib/Blob.js",
                     "~/Scripts/app/lib/moment.js",
                     "~/Scripts/app/directives/*.js",
                     "~/Scripts/app/filters/*.js",
                     "~/Scripts/app/services/*.js",
                     "~/Scripts/app/controllers/*.js",
                     "~/Scripts/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
