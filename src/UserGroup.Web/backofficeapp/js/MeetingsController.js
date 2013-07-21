var Backoffice;
(function (Backoffice) {
    /// <reference path="Url.ts" />
    /// <reference path="../../Scripts/typings/angularjs/angular-resource.d.ts" />
    /// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
    (function (Controllers) {
        Controllers.MeetingsCtrl = $['$scope', '$route', '$routeParams', '$resource', MeetingsController];

        function MeetingsController($scope, $route, $routeParams, $resource) {
            $scope.route = $route;
            $scope.routeParams = $routeParams;

            $scope.newMeeting = EmptyMeeting();
            $scope.currentMeeting = EmptyMeeting();

            $scope.meetingsResource = $resource(Backoffice.Url.Api("meetings/:id"));

            $scope.meetingsResource.query(function (meetings) {
                $scope.meetings = meetings;
            });

            $scope.setCurrent = function (meeting) {
                return $scope.meetingsResource.get({ id: meeting.Id }, function (details) {
                    return $scope.currentMeeting = details;
                });
            };
        }

        function EmptyMeeting() {
            return {
                Id: 0,
                Title: '',
                Description: '',
                StartDate: null
            };
        }
    })(Backoffice.Controllers || (Backoffice.Controllers = {}));
    var Controllers = Backoffice.Controllers;
})(Backoffice || (Backoffice = {}));
//@ sourceMappingURL=MeetingsController.js.map
