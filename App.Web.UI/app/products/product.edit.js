(function () {
    'use strict';

    angular
        .module('app.products')
        .controller('productUpdate', productUpdate);

    productUpdate.$inject = ['$location', 'dataservice', 'logger', '$stateParams', 'common'];

    function productUpdate($location, dataservice, logger, $stateParams, common) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Product Edit';
        vm.updateproduct = {};
        vm.categories = [];
        vm.unitmeasure = [];
        vm.currency = [];
        vm.locations = [];
        vm.UpdateProduct = UpdateProduct;

        activate();
       
        function activate() {
            getCurrencyList();
            getUnitMeasureList();
            getCategories();
            getLocations();
            getProduct();
            getDefaultImage()
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

        function getProduct() {
            var paramId = $stateParams.prodId;
            dataservice.getProduct(paramId).then(function (data) {
                vm.updateproduct = data;
                console.log(data);
            });
        }
        
        function getCurrencyList() {
            vm.currency = common.getCurrencyList();
        }

        function getUnitMeasureList() {
            vm.unitmeasure = common.getUnitMeasureList();
        }

        function getDefaultImage() {
            vm.updateproduct.ImgUrl = common.defaultImage();
        }

        function UpdateProduct() {
            var product = vm.updateproduct;
            console.log(product.UnitMeasure);
            var params = {
                id: product.Id
            };

            var config = {
                params: params
            };

            dataservice.updateProduct(product, config)
                .then(function (data) {
                    logger.info('Update product successfull','','Success');
                    $location.url('/products');
                }, function (error) {
                    logger.error(error, '', 'Error');
            });
        }
    }
})();
