(function () {
    'use strict';

    angular
      .module('app')
      .config(routes);

    routes.$inject = ['$stateProvider'];

    function routes($stateProvider) {
        $stateProvider
            .state('worker', {
                parent: 'main',
                url: 'worker',
                views: {
                    'content@main': {
                        templateUrl: 'app/components/worker/worker.html',
                        controller: 'WorkerController',
                        controllerAs: 'vm'
                    }
                }
            });
    }

})();