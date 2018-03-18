(function () {
    'use strict';

    angular
      .module('app')
      .config(routes);

    routes.$inject = ['$stateProvider'];

    function routes($stateProvider) {
        $stateProvider
            .state('student', {
                parent: 'main',
                url: 'student',
                views: {
                    'content@main': {
                        templateUrl: 'app/components/student/student.html',
                        controller: 'StudentController',
                        controllerAs: 'vm'
                    }
                }
            });
    }

})();