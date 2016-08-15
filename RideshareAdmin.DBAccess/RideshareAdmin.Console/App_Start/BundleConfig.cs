using System.Web;
using System.Web.Optimization;

namespace RideshareAdmin.Console
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/AdminLTE/Page").Include(
                        "~/Scripts/AdminLTE/pages/dashboard.js",
                        "~/Scripts/AdminLTE/pages/dashboard2.js"));

            bundles.Add(new ScriptBundle("~/AdminLTE/jQuery").Include(
                        "~/Scripts/AdminLTE/plugins/jQuery/jquery-2.2.3.min.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/AdminLTE/Datatables").Include(
                        "~/Scripts/AdminLTE/plugins/datatables/jquery.dataTables.min.js",
                        "~/Scripts/AdminLTE/plugins/datatables/dataTables.bootstrap.min.js",
                        "~/Scripts/AdminLTE/plugins/datatables/dataTables.bootstrap.min.js"));


            bundles.Add(new ScriptBundle("~/AdminLTE/Animations").Include(
                        "~/Scripts/AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js",
                        "~/Scripts/AdminLTE/plugins/fastclick/fastclick.js",
                        "~/ Scripts/AdminLTE/app.min.js"));
        }

    }
}
