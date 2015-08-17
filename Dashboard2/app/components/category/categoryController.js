(function () {
    'use strict';

    angular
        .module('app')
        .controller('categoryController', categoryController);

    categoryController.$inject = ['$location']; 

    function categoryController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'categoryController';

        activate();

        function activate() { }
    }
})();
