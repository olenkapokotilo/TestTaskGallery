(function () {
    "use strict";

    var app = angular.module('app', ["ngRoute"])
        .controller('UserController', UserController)
        .controller('FileController', FileController)
        .service('UserService', UserService)
        .service('FileService', FileService);

    app.config(function($routeProvider) {
        $routeProvider.when('/users',
        {
            templateUrl: 'home/users', //todo : remove
            controller: 'UserController'
        });
        $routeProvider.when('/files/:userId',
        {
            templateUrl: 'home/files',
            controller: 'FileController'
        });
    });
 
app.directive('fileInput', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, elm, attrs) {
            elm.bind('change', function () {
                $parse(attrs.fileInput)
                    .assign(scope, elm[0].files[0]);
                scope.$apply();
            });
        }
    }
}]);

app.filter('startFrom', function () {
    return function (input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});
})();