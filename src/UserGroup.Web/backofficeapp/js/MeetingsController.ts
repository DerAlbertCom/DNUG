/// <reference path="Url.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />

module Backoffice {

    export interface MeetingLine {
        Id: number;
        Title: string;
        Description?: string;
        StartDate: Date;
    }

    export interface IMeetingsControllerScope extends ng.IScope {
        meetings: MeetingLine[];
        route: ng.IRouteService;
        routeParams: ng.IRouteParamsService;
        meetingsResource: ng.resource.IResourceClass;
        newMeeting: MeetingLine;
        currentMeeting: MeetingLine;
        setCurrent: (meeting: MeetingLine) => void;
    }

    export class MeetingsController {
        constructor($scope: IMeetingsControllerScope,
            $route: ng.IRouteService,
            $routeParams: ng.IRouteParamsService,
            $resource: ng.resource.IResourceService) {

            $scope.route = $route;
            $scope.routeParams = $routeParams;

            $scope.newMeeting = this.emptyMeeting();
            $scope.currentMeeting = this.emptyMeeting();

            $scope.meetingsResource = $resource(Url.Api("meetings/:id"));

            $scope.meetingsResource.query((meetings: MeetingLine[]) => {
                $scope.meetings = meetings;
            });

            $scope.setCurrent = meeting => {
                $scope.meetingsResource.get({ id: meeting.Id }, (details) => {
                    $scope.currentMeeting = details;
                });
            };

        }

        emptyMeeting(): MeetingLine {
            return {
                Id: 0,
                Title: '',
                Description: '',
                StartDate: null
            }
        }
    }
}