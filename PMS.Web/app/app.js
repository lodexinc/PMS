
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/register", {
        controller: "registerController",
        templateUrl: "/app/views/register.html"
    });

    $routeProvider.when("/publishers", {
        controller: "publishersController",
        templateUrl: "/app/views/publishers.html"
    });

    $routeProvider.when("/books", {
        controller: "booksController",
        templateUrl: "/app/views/books.html"
    });

    $routeProvider.when("/demands", {
        controller: "bookDemandsController",
        templateUrl: "/app/views/demands.html"
    });

    $routeProvider.when("/placedemand", {
        controller: "bookDemandsController",
        templateUrl: "/app/views/demands.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

var serviceBase = 'http://localhost:10103/';
var serviceBaseResource = 'http://localhost:10104/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    apiServiceBaseResource: serviceBaseResource,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
