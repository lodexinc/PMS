'use strict';
app.controller('bookDemandsController', ['$scope', '$location', 'bookDemandsService', function ($scope, $location, bookDemandsService) {

    $scope.bookDemands = [];
    bookDemandsService.getBookDemands().then(function (results) {

        $scope.bookDemands = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

    $scope.demandMessage = "";
    $scope.placeBookDemand = function (id,title,publishYear, quantity) {
    
        $scope.demandData = {
            BookId: id,
            BookName: title,
            PublishYear: publishYear,
            Quantity: quantity,
        };

        bookDemandsService.placeBookDemand($scope.demandData).then(function (response) {

            $location.path('/demands');

        },
         function (err) {
             $scope.demandMessage = err.error_description;
         });
    };
}]);