/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />
var Backoffice;
(function (Backoffice) {
    Backoffice.Url = {
        Api: function (url) {
            return $('body').data('apiRoot') + "backoffice/" + url;
        },
        View: function (viewName) {
            return $('body').data('appRoot') + "BackOfficeApp/partials/" + viewName + ".html";
        }
    };
})(Backoffice || (Backoffice = {}));
//@ sourceMappingURL=Url.js.map
