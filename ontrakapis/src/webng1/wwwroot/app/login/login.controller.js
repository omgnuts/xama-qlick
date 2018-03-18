(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', '$http', '$state', 'auth0Service'];

    function LoginController($scope, $http, $state, auth0Service) {
        var vm = this;

        vm.auth = {
            creds: {
                username: "Testuser",
                password: "Qwer!@#12345"
            },
            login: function () {
                auth0Service.login(vm.auth.creds, function (response) {
                    if (response == "OK") {
                        auth0Service.authenticate();
                        $state.go('main');
                    }
                });
            },
        };
    }
})();