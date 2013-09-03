/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts"/>
describe("Testing Application setup", function () {
    describe("The Backoffice Module:", function () {
        var theApp;
        beforeEach(function () {
            theApp = angular.module("Backoffice");
        });

        it("should be registered", function () {
            return expect(theApp).not.toBe(null);
        });

        describe("Dependencies:", function () {
            var dependencies;
            var hasModule = function (m) {
                return dependencies.indexOf(m) >= 0;
            };
            beforeEach(function () {
                dependencies = theApp.value('Backoffice').requires;
            });

            it("should have ng-route as a dependency", function () {
                return expect(hasModule('ngRoute')).toBe(true);
            });

            it("should have ng-sanitize as a dependency", function () {
                return expect(hasModule('ngSanitize')).toBe(true);
            });

            it("should have ug-meetings as a dependency", function () {
                return expect(hasModule('ug-meetings')).toBe(true);
            });
        });
    });
});
//# sourceMappingURL=ApplicationSetup.js.map
