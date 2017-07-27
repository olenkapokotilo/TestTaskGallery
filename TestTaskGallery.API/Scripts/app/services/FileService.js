FileService.$inject = ['$http', '$q'];

function FileService($http, $q) {
    var service = this;

    service.add = function (userId, fd) {
        return $http.post('api/users/' + userId + '/files', fd,
        {
            headers: { 'Content-Type': undefined },
            transformRequest: angular.indentity
        });
    }

    service.delete = function(userId, id) {
        return $http.delete('api/users/' + userId + '/files/' + id);
    }
}