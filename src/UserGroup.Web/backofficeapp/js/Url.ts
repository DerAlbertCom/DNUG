/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module Backoffice.Url {

    function AppRoot(): string {
        return $('body').data('appRoot');
    };

    export function Api(url) {
        return AppRoot() + "api/backoffice/" + url;
    }

    export function View(viewName) {
        return AppRoot() + "backofficeapp/partials/" + viewName + ".html";
    }

}