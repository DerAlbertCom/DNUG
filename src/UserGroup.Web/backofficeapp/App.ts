/// <reference path="js/Url.ts" />
/// <reference path="../Scripts/typings/angularjs/angular-sanitize.d.ts" />
/// <reference path="../Scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />

module Backoffice.Controllers {
}
module Backoffice {
    angular.module('Backoffice', ['ngSanitize', 'ug-meetings'])
        .controller(Controllers)
        .config(['$routeProvider', ($routeProvider: ng.IRouteProvider) => {

            $routeProvider
                .when("/", { templateUrl: Url.View("admin"), controller: 'AdminCtrl' })
                .when("/meetings", { templateUrl: Url.View("meetings"), controller: 'MeetingsCtrl' })
                .when("/meetings/:id", { templateUrl: Url.View("meetings"), controller: 'MeetingsCtrl' })
                .otherwise({ redirectTo: '/' });
        }]);
}