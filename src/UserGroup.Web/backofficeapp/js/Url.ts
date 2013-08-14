/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />

module Backoffice {

    export var Url = {
        Api: (url: string) => $('body').data('apiRoot') + "backoffice/" + url,
        View: (viewName: string) => $('body').data('appRoot') + "BackOfficeApp/partials/" + viewName + ".html"
   };

}