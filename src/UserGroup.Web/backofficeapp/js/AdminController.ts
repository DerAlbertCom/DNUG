/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module Backoffice.AdminControllers {

    interface IAdminControllerScope extends ng.IScope {
    }

    function AdminController($scope: IAdminControllerScope) {
    }

    export var AdminCtrl = ['$scope', AdminController];
}