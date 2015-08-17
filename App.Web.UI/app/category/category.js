(function () {
    'use strict';

    angular
        .module('app.category')
        .controller('category', category);

    category.$inject = ['$location', 'dataservice']; 

    function category($location, dataservice) {
        /* jshint validthis:true */
        var vm = this;
        vm.categories = [];
        vm.deletecategory = deletecategory;
        activate();

        function activate() {
            getCategoryList();
        }

        function getCategoryList() {
            return dataservice.getCategories().then(function (data) {
                vm.categories = data;
            });
        }

        function deletecategory(category) {
            var id = category.Id;
            bootbox.confirm("Delete this category " + category.Name + "?", function (result) {
                if (result == true) {
                    dataservice.deleteCategory(id).then(function (data) {
                        $.each(vm.categories, function (i) {
                            if (vm.categories[i].Id === id) {
                                vm.categories.splice(i, 1);
                                return false;
                            }
                        });
                        logger.info('Category ' + category.Name + ' was deleted.', '', 'Success');
                    });
                }
            });
        }

      
    }
})();
