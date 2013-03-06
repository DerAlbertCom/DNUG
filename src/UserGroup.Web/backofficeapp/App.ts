/// <reference path="js/Url.ts" />
/// <reference path="js/MeetingsController.ts" />
/// <reference path="js/AdminController.ts" />
/// <reference path="../Scripts/typings/angularjs/angular-sanitize.d.ts" />
/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />

module Backoffice {
    var backoffice = angular.module('Backoffice', ['ngSanitize', 'ngResource']);
    backoffice.config(['$routeProvider', function ($routeProvider : ng.IRouteProviderProvider) : void {
        $routeProvider
            .when("/", { templateUrl: Url.View("admin"), controller: AdminController })
            .when("/meetings", { templateUrl: Url.View("meetings"), controller: MeetingsController })
            .when("/meetings/:id", { templateUrl: Url.View("meetings"), controller: MeetingsController })
            .otherwise({ redirectTo: '/' });        
    }]);
}