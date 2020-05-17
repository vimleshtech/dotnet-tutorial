using System.Web;
using System.Web.Optimization;

namespace EBMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-grid.css", "~/Content/bootstrap-grid.min.css",
                "~/Content/bootstrap-reboot.css", "~/Content/bootstrap-rebot-min.css",
                "~/Content/bootstrap.css", "~/Content/bootstrap.min.css", "~/Content/My.css","~/Content/my1.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/Custom").Include(
                "~/Scripts/Custom/myscript.js"));
          
        }
    }
}
