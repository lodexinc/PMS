'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.logOut = function () {
        debugger;
        authService.logOut();
        $location.path('/home');
    }

    $scope.authentication = authService.authentication;

}]);