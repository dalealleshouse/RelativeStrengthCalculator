module RelativeStrengthCalculator {
    class CalculatorInputValidatorController {
        static id = 'CalculatorInputValidatorController';

        /*@ngInject*/
        constructor(public calculationInputParser: ICalculationInputParser) {  }
    }

    class CalculatorInputValidator implements ng.IDirective {
        static id = 'rscCalculatorInputValidator';

        static factory(): ng.IDirective {
            return new CalculatorInputValidator();
        }

        restrict = 'A';
        controller = CalculatorInputValidatorController;
        require = [CalculatorInputValidator.id, 'ngModel'];

        link(scope: ng.IScope, element: ng.IAugmentedJQuery, attributes: ng.IAttributes, controllers: any[]) {
            var controller = <CalculatorInputValidatorController>controllers[0];
            var ngModelController = controllers[1];

            ngModelController.$validators.calculatorInput = (val: string) => {
                return controller.calculationInputParser.isValid(val);
            };
        }
    }

    angular.module(appName)
        .directive(CalculatorInputValidator.id, CalculatorInputValidator.factory);
}
