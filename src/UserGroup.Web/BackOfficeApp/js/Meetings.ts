/// <reference path="Url.ts" />
/// <reference path="backoffice.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module Backoffice {

    function EmptyMeeting(): IMeetingLine {
        return {
            Id: 0,
            Title: '',
            Description: '',
            StartDate: null
        };
    }
    
    var MeetingsService = ['$resource', function ($resource: ng.resource.IResourceService) {
        var service = $resource(Url.Api("meetings/:id"));
        return service;
    }];
    
    var MeetingsController = ['$scope', '$routeParams', 'meetingsService',
        function ($scope: IMeetingsControllerScope,
            $routeParams: ng.IRouteParamsService, meetingsService: IMeetingsService) {

            $scope.routeParams = $routeParams;
            $scope.newMeeting = EmptyMeeting();
                $scope.currentMeeting = EmptyMeeting();

            meetingsService.query((meetings: IMeetingLine[]) => {
                $scope.meetings = meetings;
            });

            $scope.setCurrent = meeting => meetingsService.get({ id: meeting.Id }, (details) => $scope.currentMeeting = details);

            $scope.update = () => {
            };
        }
    ];

    angular.module('ug-meetings', ['ngResource'])
        .factory('meetingsService', MeetingsService)
        .controller('MeetingsCtrl', MeetingsController);
}