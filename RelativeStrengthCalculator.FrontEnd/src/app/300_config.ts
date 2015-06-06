module RelativeStrengthCalculator {
    'use strict';

    class HtmlFiveMode {
        constructor($locationProvider: ng.ILocationProvider) {
            $locationProvider.html5Mode(true);
        }
    };

    class Routes {
        static $inject = ['$stateProvider', '$urlRouterProvider'];

        constructor($stateProvider: ng.ui.IStateProvider, $urlRouterProvider: ng.ui.IUrlRouterProvider) {
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: 'app/main/main.html',
                    controller: 'MainCtrl',
                    controllerAs: 'vm'
                });

            $urlRouterProvider.otherwise('/');
        }
    };

    angular.module(appName)
        .config(HtmlFiveMode)
        .config(Routes);
}
