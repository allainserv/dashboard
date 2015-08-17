(function () {
    'use strict';

    angular
        .module('app.common')
        .factory('common', common);

   // common.$inject = ['$http'];

    function common($http) {
        var service = {
            getUnitMeasureList: getUnitMeasureList,
            getCurrencyList: getCurrencyList,
            defaultImage: defaultImage,
            paginatorTemplateUrl: paginatorTemplateUrl
        };              
        return service;

        function getUnitMeasureList() {
           return ['Pcs', 'Box', 'Set'];
        }

        function getCurrencyList() {
            return ['(Php)', '(USD)'];
        }

        function defaultImage() {
            return 'http://localhost:60956/assets/img/default-img.png';
        }

        function paginatorTemplateUrl() {
            return '\app\pagination\dirPagination.tpl.html';
        }
    }
})();