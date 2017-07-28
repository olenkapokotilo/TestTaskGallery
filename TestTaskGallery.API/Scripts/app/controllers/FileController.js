FileController.$inject = ['$scope', '$http', '$filter', '$q', '$routeParams','$window', 'FileSaver', 'Blob', 'FileService', 'UserService'];

function FileController($scope, $http, $filter, $q, $routeParams,$window, FileSaver,Blob,  FileService, UserService) {
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
            $scope.currentUser.UploadFiles.push(response.data.Photo);
        });
    }

    $scope.deleteFile = function (id, index) {
        FileService.delete($scope.currentUser.Id, id)
            .then(function (response) {
                $scope.currentUser.UploadFiles.splice(index, 1);
        });
    }

    $scope.download = function (id, name) {
        var img = $("#file" + id);
        var data;
        $http.get(img[0].src, { responseType: 'arraybuffer' }).then(function (response) {
            data = response.data;
            var ext = getExtension(name);
            var blob = new Blob([data], { type: 'image/' + ext });
            FileSaver.saveAs(blob, name);
        });
    }



    $scope.load();
}

function getExtension(path) {
    var basename = path.split(/[\\/]/).pop(),  // extract file name from full path ...
                                               // (supports `\\` and `/` separators)
        pos = basename.lastIndexOf(".");       // get last position of `.`

    if (basename === "" || pos < 1)            // if file name is empty or ...
        return "";                             //  `.` not found (-1) or comes first (0)

    return basename.slice(pos + 1);            // extract extension ignoring `.`
}