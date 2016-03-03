'use strict';
app.factory('booksService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseResource;
    var serviceFactory = {};
    var _getbooks = function () {

        return $http.get(serviceBase + 'api/books')
            .then(function (results) {
            return results;
        });
    };
    serviceFactory.getBooks = _getbooks;
    return serviceFactory;
}]);