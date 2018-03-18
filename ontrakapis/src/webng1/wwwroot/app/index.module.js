(function () {
    'use strict';
    angular
        .module('app', [
            'ui.router',
            'ngStorage'
        ]);

    angular.module('app').run(runapp);
    runapp.$inject = ['$rootScope', '$templateCache', '$state', 'auth0Service'];

    // This automatically clear the cache whenever the ng-view content changes.
    function runapp($rootScope, $templateCache, $state, auth0Service) {
        $rootScope.$on('$viewContentLoaded', function () {
            $templateCache.removeAll();
        });

        // Check for login authentication.
        $rootScope.$on('$stateChangeStart', function (e, toState, toParams, fromState, fromParams) {
            var isLogin = toState.name === "login";
            var authenticated = auth0Service.isAuthenticated();
            if (isLogin) {
                if (authenticated) {
                    e.preventDefault();
                    $state.go(fromState.name);
                } else {
                    return;
                }
            }

            if (!authenticated) {
                // stop current execution
                e.preventDefault();

                // go to login
                $state.go('login');
            }
        });
    }
})();