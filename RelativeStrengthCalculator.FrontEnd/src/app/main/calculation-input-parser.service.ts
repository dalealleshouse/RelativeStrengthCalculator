module RelativeStrengthCalculator {
    export interface ICalculationInputParser {
        isValid: (input: string) => boolean;
        parse: (input: string) => ICalculatorRequest[];
    }

    export class CalculationInputParser implements ICalculationInputParser {
        static id = 'calculationInputParser';

        male = ['1', 'male'];
        female = ['2', 'female'];

        isValid(input: string): boolean {
            return this.parse(input) != null;
        }

        parse(input: string): ICalculatorRequest[] {
            if (!input) {
                return null;
            }

            var requests = [];
            var records = input.split(/\r\n|\r|\n/g);

            _.forEach(records, (value: string) => {
                if (!value) {
                    return true;
                }

                var temp = this.buildRecord(value);
                var request = this.parseRecord(temp);

                if (request == null) {
                    requests = null;
                    return false;
                }

                requests.push(request);
                return true;
            });

            return requests;
        }

        private buildRecord(input: string): string[] {
            if (!input) {
                return null;
            }

            return input.split(',');
        }

        private parseRecord(record: string[]): ICalculatorRequest {
            if (!record) {
                return null;
            }

            if (record.length !== 3 && record.length !== 4) {
                return null;
            }

            var request = this.defaultRequest(this.getValue(record, 0));
            request.sex = this.parseSex(this.getValue(record, 1));
            request.bodyWeight = parseFloat(this.getValue(record, 2));

            if (record.length === 4) {
                request.weight = parseFloat(this.getValue(record, 3));
            }

            if (!request.sex || isNaN(request.bodyWeight) || isNaN(request.weight)) {
                return null;
            }

            return request;
        }

        private getValue(arr: string[], index: number) {
            if (!arr[index]) {
                return '';
            }

            return arr[index].trim();
        }

        private parseSex(sex: string): string {
            var testVal = sex.toLowerCase();

            if (_.contains(this.male, testVal)) {
                return '1';
            }

            if (_.contains(this.female, testVal)) {
                return '2';
            }

            return null;
        }

        private defaultRequest(id: string): ICalculatorRequest {
            return {
                id: id,
                sex: '0',
                bodyWeight: 0,
                weight: 0
            };
        }
    }

    angular.module(appName).service(CalculationInputParser.id, CalculationInputParser);
}
