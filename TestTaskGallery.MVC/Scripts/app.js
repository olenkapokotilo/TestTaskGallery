//(function () {

    var app = angular.module('app', []);  // Will use ['ng-Route'] when we will implement routing

    app.controller('HomeController', function ($scope, $http, ProductsService) {  // here $scope is used for share data between view and controller
        $scope.Message = "Yahoooo! we have successfully done our first part.";
        $scope.productsData = null;
        $http.get('http://localhost:36061/api/values').then(function (response) {
            $scope.myWelcome = response.data;
        });
        ProductsService.GetAllRecords().then(function (d) {
            $scope.productsData = d.data; // Success
            //alert('Success !!!');
        }, function () {
            alert('Error Occured !!!'); // Failed
        });

        $scope.User = {
            Id: '',
            Name: ''
        };

        $scope.filesChanged = function(elm) {
            $scope.filesChanged = elm.files;
            $scope.$apply();
        };

        $scope.upload = function () {
            var fd = new FormdData();
            angular.forEach($scope.filesChanged, function(file) {
                fd.append('file', file);
            });
            $http.post('Home/Upload', fd,
            {
                
                transformRequest: angular.indentity,
                    headers: { 'Content-Type': undefined }
                })
                .success(function (d) {
                    console.log(d);
                });
        }
    });
    app.directive('fileInput', ['$parse', function($parse) {
        return {
            restrict: 'A',
            link: function(scope, elm, attrs) {
                elm.bind('change', function() {
                    $parse(attrs.fileInput)
                        .assign(scope, elm[0].files);
                    scope.$apply();
                });
            }
        }
    }]);


    app.factory('ProductsService', function ($http) {
        var fac = {};
        fac.GetAllRecords = function () {
            return $http.get('http://localhost:36061/api/values');
        }
        return fac;
    });



//})();