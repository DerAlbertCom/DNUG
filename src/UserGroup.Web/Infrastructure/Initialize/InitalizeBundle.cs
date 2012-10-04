using System.Web.Optimization;
using Aperea.Infrastructure.Bootstrap;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitalizeBundle : BootstrapItem
    {
        public override int Order
        {
            get { return -1; }
        }

        public override void Execute()
        {
            BundleIt(BundleTable.Bundles);
        }

        void BundleIt(BundleCollection bundles)
        {
            bundles.Clear();
            var cssBundle = new StyleBundle("~/resources/css").Include("~/content/site.css");

            var jsBundle = new ScriptBundle("~/resources/js").Include(
                "~/Scripts/jquery-1.8.2.js",
                "~/Scripts/modernizr-2.6.2.js",
                "~/Scripts/jquery-ui-i18n.js");

            bundles.Add(cssBundle);
            bundles.Add(jsBundle);
        }
    }
}