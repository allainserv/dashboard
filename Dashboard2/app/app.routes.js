(function () {
	'use strict';

	angular.module('app', ['ngRoute'])
	 .config(['$routeProvider',

		   function ($routeProvider) {
		       $routeProvider
                  .when('/products', {
                      templateUrl: 'app/components/products/products.html',
                      controller: 'productsController',
                      controllerAs: 'prodCtrl'
                  })
                  .when('/category', {
                      templateUrl: 'app/components/category/category.html',
                      controller: 'categoryController',
                      controllerAs: 'categoryCtrl'
                  })
                  .when('/location', {
                      templateUrl: 'app/components/location/location.html',
                      controller: 'locationController',
                      controllerAs: 'locationCtrl'
                  })
                   .when('/sales', {
                       templateUrl: 'app/components/sales/sales.html',
                       controller: 'salesController',
                       controllerAs: 'salesCtrl'
                   });
		   }]);

})();