(function () {
    'use strict';

    angular
        .module('app.products')
        .controller('Products', Products);

    Products.$inject = ['$location', 'dataservice', 'logger', 'common'];

    function Products($location, dataservice, logger, common) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'products';
        vm.products = [];
        vm.deleteProduct = deleteProduct;
        vm.currentPage = 1;
        vm.pageSize = 6;
        vm.defaultImage;
       
        activate();

        function activate() {
            geProducts();
            getDefaultImage();
        }

        function geProducts() {
            return dataservice.getProducts().then(function (data) {
                vm.products = data;               
            });
        }
        
        function getDefaultImage() {
            vm.defaultImage = common.defaultImage();
        }

        function deleteProduct(prod) {
            var id = prod.Id;
            bootbox.confirm("Delete this product " + prod.Name + "?", function (result) {
                if (result == true) {
                    dataservice.deleteProduct(id).then(function (data) {
                         $.each(vm.products, function (i) {
                            if (vm.products[i].Id === id) {
                                vm.products.splice(i, 1);
                                return false;
                            }
                         });
                         logger.info('Product ' + prod.Name + ' was deleted.', '', 'Success');
                    });
                }
            });
        }
       

    }

})();
