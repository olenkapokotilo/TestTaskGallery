UserService.$inject = ['$http', '$q'];
function UserService($http, $q) {
    var service = this;
    service.controller = "users";

    service.asyncGet = function () {
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

    service.get = function (id) {
        return $http.get('api/users/'+id);
    }

    service.add = function(name, birthDate) {
        return $http.post('api/users', {
                Name:name,
                BirthDate: birthDate
            }
        );
    } 
}