/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module Backoffice {

    export interface IAdminControllerScope extends ng.IScope {
    }

    export class AdminController {
        constructor(public $scope: IAdminControllerScope) {
        }
    }
}