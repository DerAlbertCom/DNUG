/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />

module Backoffice {
    var AppRoot = () => $('body').data('appRoot');

    export var Url = {
        Api : (url: string) => AppRoot() + "api/backoffice/" + url,
        View : (viewName: string) => AppRoot() + "backofficeapp/partials/" + viewName + ".html"
   };

}