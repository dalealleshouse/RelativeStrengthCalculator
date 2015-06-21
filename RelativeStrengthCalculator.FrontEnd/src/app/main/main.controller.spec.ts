module RelativeStrengthCalculator {
    'use strict';

    describe('MainController should', () => {
        beforeEach(module(appName));

        it('have loading true until after meta data returns', () => {
            var builder = new SutFactory();
            var sut = builder.build();

            expect(sut.loading).toBeTruthy();
            builder.$rootScope.$apply();
            expect(sut.loading).toBeFalsy();
        });
    });

    class SutFactory {
        $rootScope: ng.IScope;

        build(): MainController {
            var sut;

            inject(($injector: ng.auto.IInjectorService, $q: ng.IQService, $rootScope: ng.IScope) => {
                this.$rootScope = $rootScope;

                sut = $injector.get('$controller')(MainController.id, {
                    relativeStrengthService: new MockRelativeStrengthService($q)
                });
            });

            return sut;
        }
    }
}
