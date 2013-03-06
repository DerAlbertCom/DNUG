var Backoffice;
(function (Backoffice) {
    var MeetingsController = (function () {
        function MeetingsController($scope, $route, $routeParams, $resource) {
            $scope.route = $route;
            $scope.routeParams = $routeParams;
            $scope.newMeeting = this.emptyMeeting();
            $scope.currentMeeting = this.emptyMeeting();
            $scope.meetingsResource = $resource(Backoffice.Url.Api("meetings/:id"));
            $scope.meetingsResource.query(function (meetings) {
                $scope.meetings = meetings;
            });
            $scope.setCurrent = function (meeting) {
                $scope.meetingsResource.get({
                    id: meeting.Id
                }, function (details) {
                    $scope.currentMeeting = details;
                });
            };
        }
        MeetingsController.prototype.emptyMeeting = function () {
            return {
                Id: 0,
                Title: '',
                Description: '',
                StartDate: null
            };
        };
        return MeetingsController;
    })();
    Backoffice.MeetingsController = MeetingsController;    
})(Backoffice || (Backoffice = {}));
//@ sourceMappingURL=MeetingsController.js.map
