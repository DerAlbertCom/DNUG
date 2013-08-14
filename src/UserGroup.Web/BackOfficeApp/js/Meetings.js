/// <reference path="Url.ts" />
/// <reference path="backoffice.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
var Backoffice;
(function (Backoffice) {
    function EmptyMeeting() {
        return {
            Id: 0,
            Title: '',
            Description: '',
            StartDate: null
        };
    }

    var MeetingsService = [
        '$resource',
        function ($resource) {
            var service = $resource(Backoffice.Url.Api("meetings/:id"));
            return service;
        }
    ];

    var MeetingsController = [
        '$scope',
        '$routeParams',
        'meetingsService',
        function ($scope, $routeParams, meetingsService) {
            $scope.routeParams = $routeParams;
            $scope.newMeeting = EmptyMeeting();
            $scope.currentMeeting = EmptyMeeting();

            meetingsService.query(function (meetings) {
                $scope.meetings = meetings;
            });

            $scope.setCurrent = function (meeting) {
                return meetingsService.get({ id: meeting.Id }, function (details) {
                    return $scope.currentMeeting = details;
                });
            };

            $scope.update = function () {
            };
        }
    ];

    angular.module('ug-meetings', ['ngResource']).factory('meetingsService', MeetingsService).controller('MeetingsCtrl', MeetingsController);
})(Backoffice || (Backoffice = {}));
//@ sourceMappingURL=Meetings.js.map
