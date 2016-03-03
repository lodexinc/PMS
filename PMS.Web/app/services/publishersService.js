'use strict';
app.factory('publishersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseResource;
    var serviceFactory = {};
    var _getpublishers = function () {

        return $http.get(serviceBase + 'api/publishers')
            .then(function (results) {
            return results;
        });
    };
    serviceFactory.getPublishers = _getpublishers;
    return serviceFactory;
}]);