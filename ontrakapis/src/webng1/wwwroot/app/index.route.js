(function () {
    'use strict';

    site.api = function (path) {
        return 'http://localhost:18081/api/' + path;
    };

    angular.module('app').config(routes);
    routes.$inject = ['$stateProvider', '$urlRouterProvider'];

    function routes($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
    }

})();