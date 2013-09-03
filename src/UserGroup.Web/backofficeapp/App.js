var Backoffice;
(function (Backoffice) {
    angular.module('Backoffice', ['ngSanitize', 'ug-meetings', 'ngRoute']).controller(Backoffice.Controllers).config([
        '$routeProvider',
        function ($routeProvider) {
            $routeProvider.when("/", { templateUrl: Backoffice.Url.View("admin"), controller: 'AdminCtrl' }).when("/meetings", { templateUrl: Backoffice.Url.View("meetings"), controller: 'MeetingsCtrl' }).when("/meetings/:id", { templateUrl: Backoffice.Url.View("meetings"), controller: 'MeetingsCtrl' }).otherwise({ redirectTo: '/' });
        }
    ]);
})(Backoffice || (Backoffice = {}));
//# sourceMappingURL=App.js.map
