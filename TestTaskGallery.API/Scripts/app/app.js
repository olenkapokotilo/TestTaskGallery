(function () {
    "use strict";

    var app = angular.module('app', ["ngRoute"])
        .controller('HomeController', HomeController) 
        .service('FileService', FileService);

    app.config(function($routeProvider) {
        $routeProvider.when('/users',
        {
            templateUrl: 'views/question.html', //todo : remove
            controller: 'HomeController'
        });
        $routeProvider.when('/files',
        {
            templateUrl: 'home/files',
            controller: 'HomeController'
        });
    });


    

 HomeController.$inject = ['$scope', '$http', '$q', '$filter', 'FileService'];

    //todo: split into 2 controller & move to different files. Do it by small parts
 function HomeController($scope, $http, $filter, $q, FileService) { //todo: useCamel case, only order make sens. Fix order!
        $scope.currentPage = 0;
        $scope.pageSize = 3;
        $scope.usersData = [];
        $scope.allFilesForUser = [];

        $scope.numberOfPages = function () {
            return Math.ceil($scope.usersData.length / $scope.pageSize);
        }

        FileService.asyncGeUsers().then(function (d) {
            $scope.usersData = d;
            
            angular.forEach($scope.usersData, function (user) {
                user.BirthDate = moment(user.BirthDate).format('YYYY-DD-MM');
            });
        });
    
        $scope.fileChanged = function (elm) {
            $scope.fileChanged = elm.file;
            $scope.$apply();
        };

        $scope.addUser = function () {

            //todo: move to repository(service) (in the end) to hide api urls
            $http.post('api/users',  {
                Name: $scope.Name,
                BirthDate: $scope.BirthDate}
            ).then(function (d) {
                d.data.BirthDate = moment(d.data.BirthDate).format('YYYY-DD-MM');
                $scope.usersData.push(d.data);
                
                
                $scope.Name = '';
                    $scope.BirthDate = '';
                });
        }

        $scope.upload = function () {
            var fd = new FormData();
            fd.append('file', $scope.file);            
            $http.post('api/users/' + $scope.currentUser.Id + '/files', fd,
            {
                headers: { 'Content-Type': undefined },
                transformRequest: angular.indentity
            }).then(function (d) {
                $scope.currentUser.UploadFiles.push(d.data.Photo);;
            });
        }

        $scope.uploadUserFiles = function(id) {
            $scope.currentUser = $scope.usersData.find(function (el) { return el.Id == id; });
           }

        $scope.deletePhoto = function (id, index) {
            $http.delete('api/users/' + $scope.currentUser.Id + '/files/' + id)
                .then(function (d) {
                    $scope.currentUser.UploadFiles.splice(index, 1);
                    $scope.usersData.find(function (el) { return el.Id == $scope.currentUser.Id; }).UploadFiles = $scope.currentUser.UploadFiles;
                // ? delete from user.List
            });
        }
    };

 FileService.$inject = ['$http', '$q'];

 function FileService($http, $q) {
        var service = this;

        service.asyncGeUsers = function() {
            var deferred = $q.defer();
            $http.get('../api/users').
                then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.reject(response.status);
                    }
                );

            return deferred.promise;
        }

        }

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