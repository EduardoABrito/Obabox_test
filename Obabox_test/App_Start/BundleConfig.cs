using System.Web;
using System.Web.Optimization;

namespace Obabox_test
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/Script").Include(
                        "~/Content/Shared/Script/jquery.js",
                        "~/Content/Shared/Script/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Shared/Css/bootstrap.css"));
        }
    }
}
