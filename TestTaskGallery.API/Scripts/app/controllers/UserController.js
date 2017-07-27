UserController.$inject = ['$scope', '$http', '$filter', '$q', 'UserService'];

function UserController($scope, $http, $filter, $q, UserService) {
    var birthDateFormat = 'YYYY-DD-MM'; //TODO: ? in $scope
    $scope.currentPage = 0;
    $scope.pageSize = 3;
    $scope.usersData = [];

    $scope.numberOfPages = function () {
        return Math.ceil($scope.usersData.length / $scope.pageSize);
    }

    $scope.loadUsers = function() {
        UserService.asyncGet().then(function (response) {
            angular.forEach(response, function (user) {
                user.BirthDate = moment(user.BirthDate).format(birthDateFormat);
                $scope.usersData.push(user);
            });
        });
    }

    $scope.addUser = function() { //TODO: add validation
        UserService.add($scope.Name, $scope.BirthDate).then(function (response) {
            response.data.BirthDate = moment(response.data.BirthDate).format(birthDateFormat);
            $scope.usersData.push(response.data);
            $scope.Name = '';
            $scope.BirthDate = '';
        });

    }
    $scope.loadUsers();
}