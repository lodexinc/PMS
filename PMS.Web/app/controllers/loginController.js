'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', 'ngAuthSettings', function ($scope, $location, authService, ngAuthSettings) {

    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.message = "";

    $scope.login = function () {
        //debugger;
        authService.login($scope.loginData).then(function (response) {

            $location.path('/publishers');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
   
}]);
