(function () {
    'use strict';

    angular
        .module('app.category')
        .controller('categoryUpdate', category);

    category.$inject = ['$location', 'dataservice', 'logger', 'common', '$stateParams'];

    function category($location, dataservice, logger, common, $stateParams) {
        /* jshint validthis:true */
        var vm = this;
        
        vm.category = {};
        vm.save = save;

        activate();

        function activate() {
            getCategory();
        }

        function save() {
            var category = vm.category;

            var params = {
                id: category.Id
            };

            var config = {
                params: params
            };

            dataservice.updateCategory(category, config)
                 .then(function (data) {
                     logger.info('Category was updated', '', 'Success');
                     $location.url('masterfile/category');
                 }, function (error) {
                     logger.error(error, '', 'Error');
                 });
        }

        function getCategory() {
            var paramId = $stateParams.catId;
            dataservice.getCategory(paramId).then(function (data) {
                vm.category = data;
               // console.log(data);
            });
        }
    }
})();
