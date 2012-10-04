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
            var cssBundle = new Bundle("~/resource/css", new CssMinify());
            cssBundle.AddFile("~/content/site.css");

            var jsBundle = new Bundle("~/resource/js", new JsMinify());
            jsBundle.AddFile("~/Scripts/jquery-1.7.1.js");
            jsBundle.AddFile("~/Scripts/modernizr-2.0.6-development-only.js");
            jsBundle.AddFile("~/Scripts/jquery-ui-i18n.js");

            bundles.Add(cssBundle);
            bundles.Add(jsBundle);
        }
    }
}