'use strict';
app.factory('bookDemandsService', ['$http', '$q', 'ngAuthSettings', function ($http, $q, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseResource;
    var serviceFactory = {};

    var _getbookdemands = function (userId) {

        var getdemandData = {
            userId: userId
        };

        return $http.get(serviceBase + 'api/demands', getdemandData )
            .then(function (results) {
            return results;
        });
    };

    var _placebookDemand = function (demandData) {
        //debugger;

        var deferred = $q.defer();

        $http.post(serviceBase + 'api/demands/place', demandData, { headers: { 'Content-Type': 'application/json' } }).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

    serviceFactory.getBookDemands = _getbookdemands;
    serviceFactory.placeBookDemand = _placebookDemand;
    return serviceFactory;
}]);