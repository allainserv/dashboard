(function () {
    'use strict';

    angular
        .module('app.category')
        .controller('categoryAdd', category);

    category.$inject = ['$location', 'dataservice', 'logger', 'common'];

    function category($location, dataservice, logger, common) {
        /* jshint validthis:true */
        var vm = this;
        
        vm.category = {};
        vm.save = save;

        activate();

        function activate() { }

        function save() {
            var category = vm.category;

            dataservice.addCategory(category)
                 .then(function (data) {
                     logger.info('New category was added', '', 'Success');
                     $location.url('masterfile/category');
                 }, function (error) {
                     logger.error(error, '', 'Error');
                 });
        }
    }
})();
