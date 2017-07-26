(function () {
    "use strict";

 var app=   angular.module('app', [])
        .controller('HomeController', HomeController) 
        .service('PhotoService', PhotoService);

 HomeController.$inject = ['$scope', '$http', '$q', '$filter', 'PhotoService'];

 function HomeController($scope, $http, $filter, $q, PhotoService) {
        $scope.currentPage = 0;
        $scope.pageSize = 3;
        $scope.productsData = [];
        $scope.allFilesForUser = [];

        $scope.numberOfPages = function () {
            return Math.ceil($scope.productsData.length / $scope.pageSize);
        }

        PhotoService.asyncGeUsers().then(function (d) {
            $scope.productsData = d;
            
            angular.forEach($scope.productsData, function(user) {
                user.BirthDate = moment(user.BirthDate).format('YYYY-DD-MM');
            });
        });
    
        $scope.fileChanged = function (elm) {
            $scope.fileChanged = elm.file;
            $scope.$apply();
        };

        $scope.addUser = function() {
            $http.post('api/addUser',  {
                Name: $scope.Name,
                BirthDate: $scope.BirthDate}
            ).then(function (d) {
                d.data.BirthDate = moment(d.data.BirthDate).format('YYYY-DD-MM');
                $scope.productsData.push(d.data);
                
                
                $scope.Name = '';
                    $scope.BirthDate = '';
                });
        }

        $scope.upload = function () {
            var fd = new FormData();
            fd.append('userId', $scope.currentUser.Id);
            fd.append('file', $scope.file);            
            $http.post('api/addFile', fd,
            {
                headers: { 'Content-Type': undefined },
                transformRequest: angular.indentity
            }).then(function (d) {
                var newPhoto = d.data.Photo;
                PhotoService.asyncGePhotos(d.data.Photo.Id).then(function (d) {
                    newPhoto.bytes = d;
                    $scope.currentUser.UploadFiles.push(newPhoto);
                });
                });
        }

        $scope.uploadUserFiles = function(id) {
            $scope.currentUser = $scope.productsData.find(function (el) { return el.Id == id; });
           angular.forEach($scope.currentUser.UploadFiles, function (file) {
                PhotoService.asyncGePhotos(file.Id).then(function (d) {
                    $scope.currentUser.UploadFiles.find(function (el) { return el.Id == id; }).bytes = d;
                });
            });
           

            
        }

        $scope.deletePhoto = function (id, index) {
            $http.delete('api/deletePhoto', { params: { 'fileName': id } })
                .then(function (d) {
                    $scope.currentUser.UploadFiles.splice(index, 1);
                $scope.productsData.find(function(el) { return el.Id == $scope.currentUser.Id; }).UploadFiles = $scope.currentUser.UploadFiles;
                // ? delete from user.List
            });
        }
    };

 PhotoService.$inject = ['$http','$q'];

 function PhotoService( $http,$q) {
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

        service.asyncGePhotos = function (userId) {
            var config = {
                params: { 'fileId': userId }
            };
            var deferred = $q.defer();
            $http.get('api/files', config).
                then(function success(response) {
                    deferred.resolve(response.data);
                }, function error(response) {
                    deferred.reject(response.status);
                });

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