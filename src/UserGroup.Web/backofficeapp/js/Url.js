/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />
var Backoffice;
(function (Backoffice) {
    var AppRoot = function () {
        return $('body').data('appRoot');
    };

    Backoffice.Url = {
        Api: function (url) {
            return AppRoot() + "api/backoffice/" + url;
        },
        View: function (viewName) {
            return AppRoot() + "backofficeapp/partials/" + viewName + ".html";
        }
    };
})(Backoffice || (Backoffice = {}));
//@ sourceMappingURL=Url.js.map
