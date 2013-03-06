var Backoffice;
(function (Backoffice) {
    (function (Url) {
        function AppRoot() {
            return $('body').data('appRoot');
        }
        ;
        function Api(url) {
            return AppRoot() + "api/backoffice/" + url;
        }
        Url.Api = Api;
        function View(viewName) {
            return AppRoot() + "backofficeapp/partials/" + viewName + ".html";
        }
        Url.View = View;
    })(Backoffice.Url || (Backoffice.Url = {}));
    var Url = Backoffice.Url;
})(Backoffice || (Backoffice = {}));
//@ sourceMappingURL=Url.js.map
