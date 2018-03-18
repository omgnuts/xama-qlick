(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainController', MainController);

    MainController.$inject = ['$scope', '$http', '$state', 'auth0Service'];

    function MainController($scope, $http, $state, auth0Service) {
        var vm = this;

        vm.logout = function () {
            auth0Service.logout();
            $state.go('login');
        };
    }
})();