(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('serviceProvider', serviceProvider);

   // serviceprovider.$inject = ['$http'];

    function serviceProvider() {
        var service = {
            serviceAPI: serviceAPI
        };

        return service;

        function serviceAPI() {
            var serviceBase = 'http://localhost:58996/';
      
            return serviceBase;
        }
    }
})();