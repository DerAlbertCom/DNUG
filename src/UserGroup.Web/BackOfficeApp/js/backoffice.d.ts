/// <reference path="../../Scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />

declare module Backoffice {

    interface IMeetingLine {
        Id: number;
        Title: string;
        Description?: string;
        StartDate: Date;
    }

    interface IMeetingsControllerScope extends ng.IScope {
        meetings: IMeetingLine[];
        routeParams: ng.IRouteParamsService;
        newMeeting: IMeetingLine;
        currentMeeting: IMeetingLine;
        setCurrent: (meeting: IMeetingLine) => void;
        update: () => void;
    }

    interface IMeetingsService extends ng.resource.IResourceClass {
    }
}
