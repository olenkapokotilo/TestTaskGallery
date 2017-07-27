FileController.$inject = ['$scope', '$http', '$filter', '$q', '$routeParams', 'FileService', 'UserService'];

function FileController($scope, $http, $filter, $q, $routeParams, FileService, UserService) {
    $scope.userId = $routeParams.userId;
    
    $scope.load = function() {
        UserService.get($scope.userId).then(function (response) {
            $scope.currentUser = response.data;
        });
    }
    
    $scope.fileChanged = function (elm) {
        $scope.fileChanged = elm.file;
        $scope.$apply();
    };

    $scope.upload = function () {
        var fd = new FormData();
        fd.append('file', $scope.file);            
        FileService.add($scope.currentUser.Id, fd).then(function (response) {
            $scope.currentUser.UploadFiles.push(response.data.Photo);;
        });
    }

    $scope.deleteFile = function (id, index) {
        FileService.delete($scope.currentUser.Id, id)
            .then(function (response) {
                $scope.currentUser.UploadFiles.splice(index, 1);
                //$scope.usersData.find(function (el) { return el.Id == $scope.currentUser.Id; }).UploadFiles = $scope.currentUser.UploadFiles;
            // ? delete from user.List
        });
    }

    $scope.load();
}