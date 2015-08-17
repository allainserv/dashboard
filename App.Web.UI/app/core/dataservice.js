(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('dataservice', dataservice);

    dataservice.$inject = ['$http','$location','serviceProvider','logger'];

    function dataservice($http, $location, serviceProvider, logger) {
        var serviceBase = serviceProvider.serviceAPI();

        var service = {
            getProducts: getProducts,
            getProduct: getProduct,
            addProduct: addProduct,
            updateProduct: updateProduct,
            deleteProduct: deleteProduct,
            /*category*/
            addCategory: addCategory,
            updateCategory: updateCategory,
            deleteCategory: deleteCategory,
            getCategory: getCategory,
            getCategories: getCategories,

            getLocations: getLocations,
            getSample: getSample
            //addProduct: addProduct,
            //updateProduct: updateProduct
        };

        return service;

        /*Implementation*/
        
        function getProducts() {
            return $http.get(serviceBase + '/api/products')
              .then(getProductsComplete)
              .catch(function (message) {
                 // logger.error('Error occured',message,'error');
                  $location.url('/');
              });

            function getProductsComplete(data, status, headers, config) {
                return data.data;
            }
        }

        function getProduct(id) {
            return $http.get(serviceBase + '/api/products/' + id)
              .then(getProductsComplete)
              .catch(function (message) {
                  // logger.error('Error occured',message,'error');
                  $location.url('/');
              });

            function getProductsComplete(data, status, headers, config) {
                return data.data;
            }
        }

        function addProduct(product) {
            return $http.post(serviceBase + '/api/products', product);
        }

        function updateProduct(product, config) {
            return $http.put(serviceBase + '/api/products/', product, config);
        }

        function deleteProduct(id) {
            return $http.delete(serviceBase + '/api/products/' + id);
        }
        
        /*Category Service*/

        function addCategory(category) {
            return $http.post(serviceBase + '/api/categories', category);
        }

        function getCategories() {
            return $http.get(serviceBase + '/api/categories')
              .then(getCategoriesComplete)
              .catch(function (message) {
                  logger.error( message,'', 'error');
                  $location.url('/');
              });

            function getCategoriesComplete(data, status, headers, config) {
                return data.data;
            }
        }

        function updateCategory(category,config) {
            return $http.put(serviceBase + '/api/categories/', category, config);
        }

        function deleteCategory(id) {
            return $http.delete(serviceBase + '/api/categories/' + id);
        }

        function getCategory(catId) {
            return $http.get(serviceBase + '/api/categories/' + catId)
              .then(completed)
              .catch(function (message) {
                  // logger.error('Error occured',message,'error');
                  $location.url('/dashboard');
              });

            function completed(data, status, headers, config) {
                return data.data;
            }
        }

        /*Location Service*/

        function getLocations() {
            return $http.get(serviceBase + '/api/locations')
              .then(getLocationComplete)
              .catch(function (message) {
                  logger.error(message, '', 'error');
                  $location.url('/');
              });

            function getLocationComplete(data, status, headers, config) {
                return data.data;
            }
        }

        function getSample() {
            return $http.get('http://localhost:60661/api/sample')
             .then(getSampleComplete)
             .catch(function (message) {
                 logger.error(message, '', 'error');
                 $location.url('/');
             });

            function getSampleComplete(data, status, headers, config) {
                return data.data;
            }

        }
               
    }
})();