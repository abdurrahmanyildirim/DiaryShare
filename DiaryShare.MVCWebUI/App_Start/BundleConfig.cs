using System.Web.Optimization;

namespace DiaryShare.MVCWebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                "~/Scripts/jquery.signalR-{version}.js"));

            bundles.Add(new StyleBundle("~/bundle/style").Include("~/Content/bootstrap.css", "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}