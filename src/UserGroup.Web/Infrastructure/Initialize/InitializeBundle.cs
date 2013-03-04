using System.Web.Optimization;
using Aperea.Infrastructure.Bootstrap;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitializeBundle : BootstrapItem
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
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/modernizr-{version}.js"
                );

            var cssBackofficeBundle = new StyleBundle("~/resources/backoffice")
                .Include("~/content/bootstrap.css","~/content/backoffice.css");
            var jsBackofficeBundle = new ScriptBundle("~/resources/backoffice").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-bootstrap.js",
                "~/Scripts/i18n/angular-locale_de-de.js",
                "~/Scripts/i18n/angular-locale_en-us.js"
                );

            var jsValBundle = new ScriptBundle("~/resources/jsval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                );

            bundles.Add(cssBundle);
            bundles.Add(jsBundle);
            bundles.Add(jsBackofficeBundle);
            bundles.Add(jsValBundle);
        }
    }
}