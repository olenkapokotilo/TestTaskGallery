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

        PhotoService.asyncGetData().then(function (d) {
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
            fd.append('userId', $scope.currentUserId);
            fd.append('file', $scope.file);
            
            
            $http.post('api/values', fd,
            {
                transformRequest: angular.indentity,
                headers: { 'Content-Type': undefined }
            })
                .then(function (d) {
                    angular.forEach(d.data, function (file, key) {
                        $scope.productsData.find(function (el) { return el.Id == file.UserId; }).UploadFiles.push(file);

                    });
                    
                });
        }

        $scope.uploadUserFiles = function(id) {
            $scope.currentUserId = id;
            $scope.allFilesForUser = $scope.productsData.find(function (el, index) { return el.Id == id; });
        }

        $scope.deletePhoto = function (id, index) {
            $http.delete('api/deletePhoto', { params: { 'id': id } })
                .then(function (d) {
                    $scope.allFilesForUser.UploadFiles.splice(index, 1);
                });
        }
    };

 PhotoService.$inject = ['$http','$q'];

 function PhotoService( $http,$q) {
        var service = this;

        service.asyncGetData = function() {
            var deferred = $q.defer();
            $http.get('api/users').
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




//app.factory('ProductsService', function ($http) {
//    var fac = {};
//    fac.GetAllRecords = function () {
//        return $http.get('api/users');
//    }
//    return fac;
//});


//app.factory('dataService', function($http, $q) {
//    return {
//        asyncGetData: function () {
//            var deferred = $q.defer();
//            $http.get('api/users').
//                then(function success(response) {
//                        deferred.resolve(response.data);
//                    }, function error(response) {
//                        deferred.reject(response.status);
//                    }
//                );

//            return deferred.promise;
//        }
//    }
//});
})();