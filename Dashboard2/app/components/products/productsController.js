(function () {
    'use strict';
    //angular
    //   // .module('app.friend',[])
    //    .module('mainApp')
    //    .controller('FriendController', FriendController);

    //FriendController.$inject = ['$scope', '$log', 'FriendService'];

    angular
        .module('app')
        .controller('productsController', productsController);

    productsController.$inject = ['$location', 'productService'];

    function productsController($location, productService) {
        /* jshint validthis:true */
        var vm = this;
        vm.Products = {};
        vm.errorMessage;
        vm.title = 'productsController';

        activate();

        function activate() {
            productService.getProductsData()
            .then(function (data) {
                vm.Products = data;
            }, function (error) {
                vm.errorMessage = error.Message;
                console.log(error.Message)
            });
        }
    }
})();
