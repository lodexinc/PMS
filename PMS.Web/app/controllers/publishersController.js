'use strict';
app.controller('publishersController', ['$scope', 'publishersService', function ($scope, publishersService) {

    $scope.publishers = [];
    publishersService.getPublishers().then(function (results) {

        $scope.publishers = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);