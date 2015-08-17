(function() {
    'use strict';

    angular
        .module('app')
        .directive('productList', productList);

    function productList() {
         var directive = {
            restrict: "E",
            templateUrl: 'app/shared/product/product-list.html'
        };
        return directive;
    }
})();

