(function () {
    'use strict';

    angular
        .module('app')
        .controller('StudentController', StudentController);

    StudentController.$inject = ['$scope', '$http'];

    function StudentController($scope, $http) {
        var vm = this;

        vm.students = {
            data: [],
            inputs: {},
            edit: function (data) {
                vm.students.inputs = data;
            },
            clear: function() {
                vm.students.inputs.id = 0;
            },
            update: function () {
                $http.put(site.api('students/' + vm.students.inputs.id), JSON.stringify(vm.students.inputs))
                    .then(function (response) {
                        // Re-load data
                        if (response.status == 204) {
                            var data = $.grep(vm.students.data, function (e) {
                                return e.id == vm.students.inputs.id;
                            });

                            data.firstName = vm.students.inputs.firstName;
                            data.lastName = vm.students.inputs.lastName;
                            data.email = vm.students.inputs.email;
                        }
                        // Close dialog
                        $('#studentForm').modal('toggle');
                    });
            },
            create: function () {
                $http.post(site.api('students'), JSON.stringify(vm.students.inputs))
                    .then(function (response) {
                        // Re-load data
                        vm.students.data.push(response.data);

                        // Close dialog
                        $('#studentForm').modal('toggle');
                    });
            },
            deleto: function (key) {
                $http.delete(site.api('students/' + key))
                    .then(function (response) {
                        if (response.status == 204) {
                            vm.students.data = $.grep(vm.students.data, function (e) {
                                return e.id != key;
                            });
                        }
                    });
            }
        }

        // Load all 
        $http.get(site.api('students'))
            .then(function (response) {
                vm.students.data = response.data;
            });
    }
})();