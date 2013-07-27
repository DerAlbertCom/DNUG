/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module Backoffice.Controllers {

    interface IAdminControllerScope extends ng.IScope {
    }

    export var AdminCtrl = ['$scope', AdminController];

    function AdminController($scope: IAdminControllerScope) {
    }

}