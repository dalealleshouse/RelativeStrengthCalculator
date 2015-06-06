module RelativeStrengthCalculator {
    'use strict';

    describe('controllers', function() {
        var scope;

        beforeEach(module('RelativeStrengthCalculator'));

        beforeEach(inject(function($rootScope: ng.IRootScopeService) {
            scope = $rootScope.$new();
        }));

        it('should define more than 5 awesome things', inject(function($controller: ng.IControllerService) {
            expect(scope.awesomeThings).toBeUndefined();

            $controller('MainCtrl', {
                $scope: scope
            });

            expect(angular.isArray(scope.awesomeThings)).toBeTruthy();
            expect(scope.awesomeThings.length > 5).toBeTruthy();
        }));

        it('should do something else', inject(function($controller: ng.IControllerService) {
            expect(scope.awesomeThings).toBeUndefined();

            $controller('MainCtrl', {
                $scope: scope
            });

            expect(angular.isArray(scope.awesomeThings)).toBeTruthy();
            expect(scope.awesomeThings.length > 5).toBeTruthy();
        }));
    });
}
