(function () {
    'use strict';

    angular.module('config.routes', [
        // Angular modules
         'ui.router'
    ]).config(routeConfig);

    function routeConfig($stateProvider, $urlRouterProvider) {
       
        $stateProvider
            .state('dashboard', {
                url: '/dashboard',
                templateUrl: 'app/dashboard/dashboard.html',
                controller: 'Dashboard',
                controllerAs: 'vm'
            })

            /*products route*/
            .state('products', {
                url: '/products',
                templateUrl: 'app/products/products.html',
                controller: 'Products',
                controllerAs: 'vm'
            })
            .state('product/add', {
                url: '/product/add',
                templateUrl: 'app/products/product.add.html',
                controller: 'productAdd',
                controllerAs: 'vm'
            })
             .state('product/edit', {
                 url: '/product/edit/:prodId',
                 templateUrl: 'app/products/product.edit.html',
                 controller: 'productUpdate',
                 controllerAs: 'vm'
             })
            /*-----category----*/
             .state('masterfile/category', {
                 url: '/masterfile/category',
                 templateUrl: 'app/category/category.html',
                 controller: 'category',
                 controllerAs: 'vm'
             })
             .state('masterfile/category/add-new', {
                 url: '/masterfile/category/add-new',
                 templateUrl: 'app/category/category.form.html',
                 controller: 'categoryAdd',
                 controllerAs: 'vm'
             })
             .state('masterfile/category/edit', {
                 url: '/masterfile/category/edit/:catId',
                 templateUrl: 'app/category/category.form.html',
                 controller: 'categoryUpdate',
                 controllerAs: 'vm'
             })


        $urlRouterProvider.otherwise('/dashboard');

    }

})();
