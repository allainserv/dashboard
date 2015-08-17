(function () {
    'use strict';

    angular
        .module('app.products')
        .controller('productAdd', productAdd);

    productAdd.$inject = ['$location', 'dataservice', 'logger' , 'common'];

    function productAdd($location, dataservice, logger, common) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Product Add';
        vm.newproduct = {};
        vm.newproduct.UnitMeasure = 'Pcs';
        vm.newproduct.Currency = '(Php)';
        vm.newproduct.CategoryId = 1;
        vm.newproduct.LocationId = 1;
        vm.categories = [];
        vm.locations = [];
        vm.unitmeasure = [];
        vm.currency = [];
        vm.defaultImage;
        vm.AddProduct = AddProduct;

        activate();
       
        function activate() {
            getCurrencyList();
            getUnitMeasureList();
            getCategories();
            getLocations();
            getDefaultImage();
        }

        function getCategories() {
            dataservice.getCategories().then(function (data) {
                vm.categories = data;               
            });
        }

        function getLocations() {
             dataservice.getLocations().then(function (data) {
                vm.locations = data;       
            });
        }

        function getCurrencyList() {
            vm.currency = common.getCurrencyList();
        }

        function getUnitMeasureList() {
            vm.unitmeasure = common.getUnitMeasureList();
        }

        function getDefaultImage() {            
            vm.defaultImage = common.defaultImage();
        }

        function AddProduct() {
            var product = vm.newproduct;

            dataservice.addProduct(product)
                 .then(function (data) {
                     logger.info('Added product successfull', '', 'Success');
                     $location.url('/products');
                 }, function (error) {
                     logger.error(error, '', 'Error');
             });
                
        }
    }
})();
