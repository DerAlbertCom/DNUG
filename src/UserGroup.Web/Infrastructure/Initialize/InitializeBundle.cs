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
            bundles.Add(new StyleBundle("~/resources/css").Include("~/content/site.css"));
            bundles.Add(new ScriptBundle("~/resources/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/modernizr-{version}.js"
                ));

            bundles.Add(new StyleBundle("~/resources/backofficecss")
                .Include(
                    "~/content/bootstrap.css",
                    "~/content/bootstrap-responsive.css",
                    "~/content/backoffice.css"));

            bundles.Add(new ScriptBundle("~/resources/spajs").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-bootstrap.js",
                "~/Scripts/i18n/angular-locale_de-de.js"
                ));

            bundles.Add(new ScriptBundle("~/resources/backofficejs")
                .IncludeDirectory("~/backofficeapp/js", "*.js", true)
                .Include("~/backofficeapp/App.js"));


            bundles.Add(new ScriptBundle("~/resources/jsval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));
        }
    }
}