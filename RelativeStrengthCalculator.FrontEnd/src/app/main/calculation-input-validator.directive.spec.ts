module RelativeStrengthCalculator {
    describe('rscCalculatorInputValidator should', () => {
        beforeEach(() => {
            angular.mock.module(appName);
        });

        it('set form to invalid for invalid input', () => {
            var builder = new SutBuilder();

            builder.form.textInput.$setViewValue('foo');
            builder.$scope.$digest();
            expect(builder.form.$invalid).toEqual(true);
            expect(builder.form.$valid).toEqual(false);
        });

        it('set form to valid for invalid input', () => {
            var builder = new SutBuilder();

            builder.form.textInput.$setViewValue('some value,1,3,4\n some other value, 1,3,4');
            builder.$scope.$digest();
            expect(builder.form.$invalid).toEqual(false);
            expect(builder.form.$valid).toEqual(true);
        });
    });

    interface IMockScope extends ng.IScope {
        calcInput: string;
        model: {
            calcInput: string;
        };
        form: any;
    }

    class SutBuilder {
        $scope: IMockScope;
        form: any;

        constructor() {
            inject(($injector: ng.auto.IInjectorService) => {
                var $compile: ng.ICompileService = $injector.get('$compile');
                this.$scope = $injector.get('$rootScope');
                var element = angular.element('<form name="form"><textarea name="textInput" ng-model="calcInput" rsc-calculator-input-validator></textarea></form>');

                this.$scope.calcInput = 'bar';

                $compile(element)(this.$scope);
                this.form = this.$scope.form;
            });
        }
    }
}
