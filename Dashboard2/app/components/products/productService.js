(function () {
    'use strict';

    angular
        .module('app')
        .service('productService', productService);

    productService.$inject = ['$http'];

    function productService($http) {
        this.getProductsData = getProductsData;

        function getProductsData() {
            return $http.get('/api/products')
                .then(function (response) {
                    if (typeof response.data === 'object') {
                        return response.data;
                    } else {
                        // invalid response
                        return $q.reject(response.data);
                    }
                }, function (response) {
                    // something went wrong
                    return $q.reject(response.data);
                });
        }
    }
})();