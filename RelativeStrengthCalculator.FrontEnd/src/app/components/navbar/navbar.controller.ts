module RelativeStrengthCalculator {
    'use strict';

    export interface INavbarScope extends ng.IScope {
        date: Date
    }

    export class NavbarCtrl {
        /* @ngInject */
        constructor($scope: INavbarScope) {
            $scope.date = new Date();
        }
    }

    angular.module(appName).controller('NavbarCtrl', NavbarCtrl);
}
