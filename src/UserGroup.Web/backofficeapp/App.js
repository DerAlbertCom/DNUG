var Backoffice;
(function (Backoffice) {
    var backoffice = angular.module('Backoffice', [
        'ngSanitize', 
        'ngResource'
    ]);
    backoffice.config([
        '$routeProvider', 
        function ($routeProvider) {
            $routeProvider.when("/", {
                templateUrl: Backoffice.Url.View("admin"),
                controller: Backoffice.AdminController
            }).when("/meetings", {
                templateUrl: Backoffice.Url.View("meetings"),
                controller: Backoffice.MeetingsController
            }).when("/meetings/:id", {
                templateUrl: Backoffice.Url.View("meetings"),
                controller: Backoffice.MeetingsController
            }).otherwise({
                redirectTo: '/'
            });
        }    ]);
})(Backoffice || (Backoffice = {}));
//@ sourceMappingURL=App.js.map
