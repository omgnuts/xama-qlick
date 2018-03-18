(function () {
    'use strict';

    angular
      .module('app')
      .config(routes);

    routes.$inject = ['$stateProvider'];

    function routes($stateProvider) {
        $stateProvider
            .state('main', {
                url: '/',
                views: {
                    'main': {
                        templateUrl: 'app/main/main.html',
                        controller: 'MainController',
                        controllerAs: 'vm'
                    },
                    'content@main': {
                        templateUrl: 'app/components/home/home.html',
                    }
                }
            })

        ;
    }

})();