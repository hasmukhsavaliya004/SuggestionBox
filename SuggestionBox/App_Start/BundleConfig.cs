using System.Web;
using System.Web.Optimization;

namespace SuggestionBox
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        , "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
               "~/Content/BootStrap/bootstrap.css"
               , "~/Content/BootStrap/sb-admin.css"
               , "~/Content/BootStrap/StyleSheet.css"));
        }
    }
}