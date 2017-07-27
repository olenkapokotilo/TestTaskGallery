(function () {
    "use strict";

    var app = angular.module('app', ["ngRoute", "app.directives", "app.filters"])
        .controller('UserController', UserController)
        .controller('FileController', FileController)
        .service('UserService', UserService)
        .service('FileService', FileService);

    app.config(function($routeProvider) {
        $routeProvider.when('/users',
        {
            templateUrl: 'home/users', 
            controller: 'UserController'
        });
        $routeProvider.when('/files/:userId',
        {
            templateUrl: 'home/files',
            controller: 'FileController'
        });
        $routeProvider.otherwise({ redirectTo: 'users' });
    });
})();