(function () {
    'use strict';

    angular
        .module('app')
        .controller('WorkerController', WorkerController);

    WorkerController.$inject = ['$scope', '$http'];

    function WorkerController($scope, $http) {
        var vm = this;

        vm.workers = {
            data: [],
            inputs: {},
            create: function () {
                $http.post(site.api('workers'), JSON.stringify(vm.workers.inputs))
                    .then(function (response) {
                        // Re-load data
                        vm.workers.data.push(response.data);
                        // Close dialog
                        $('#formCreate').modal('toggle');
                    });
            }
        }

        // Load all 
        $http.get(site.api('workers'))
            .then(function (response) {
                vm.workers.data = response.data;
            });
    }
})();