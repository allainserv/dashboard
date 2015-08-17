(function () {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('Dashboard', Dashboard);

    Dashboard.$inject = ['$location', 'logger'];

    function Dashboard($location, logger) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'dashboard';

        activate();

        function activate() {
            //logger.info('Error content','', 'title');
        }
    }
})();
