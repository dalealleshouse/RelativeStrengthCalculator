module RelativeStrengthCalculator {
    'use strict';

    class HtmlFiveMode {
        constructor($locationProvider: ng.ILocationProvider) {
            $locationProvider.html5Mode(true);
        }
    };

    class Routes {
        constructor($stateProvider: ng.ui.IStateProvider, $urlRouterProvider: ng.ui.IUrlRouterProvider) {
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: 'app/main/main.html',
                    controller: 'MainController',
                    controllerAs: 'vm'
                });

            $urlRouterProvider.otherwise('/');
        }
    };

    class Theme {
        constructor($mdThemingProvider: angular.material.MDThemingProvider) {
            $mdThemingProvider.theme('default')
                .primaryPalette('blue-grey');
        }
    }

    angular.module(appName)
        .config(HtmlFiveMode)
        .config(Routes)
        .config(Theme);
}
