/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts"/>

describe("Testing application setup", ()=> {
    describe("The Backoffice Module:", ()=>{

        var theApp;
        beforeEach(()=> {
            theApp = angular.module("Backoffice");
        });

        it("should be registered", ()=> expect(theApp).not.toBe(null));


       describe("Dependencies:", ()=> {

           var dependencies;
           var hasModule =  (m) => dependencies.indexOf(m) >= 0;

           beforeEach(()=> {
                dependencies = theApp.value('Backoffice').requires;
           });

           it("should have ng-route as a dependency",
               () => expect(hasModule('ngRoute')).toBe(true));

           it("should have ng-sanitize as a dependency",
               () => expect(hasModule('ngSanitize')).toBe(true));

           it("should have ug-meetings as a dependency",
               () => expect(hasModule('ug-meetings')).toBe(true));
        });
    });
});