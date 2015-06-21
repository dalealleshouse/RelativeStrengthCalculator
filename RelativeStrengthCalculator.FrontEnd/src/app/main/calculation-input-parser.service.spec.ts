module RelativeStrengthCalculator {
    describe('RelativeStrengthService', () => {
        var sut: CalculationInputParser;

        beforeEach(() => {
            angular.mock.module(appName);
            sut = new SutFactory().build();
        });

        describe('isValid should', () => {
            it('return false if null', () => {
                expect(sut.isValid(null)).toEqual(false);
            });

            it('return false if does not 2 or 3 commas', () => {
                var result = sut.isValid('some input,male');
                expect(result).toEqual(false);

                result = sut.isValid('some input,male,1,3,1444');
                expect(result).toEqual(false);
            });

            it('return true when in form id,sex,bodyWeight', () => {
                var result = sut.isValid('some identifier,Male,100');
                expect(result).toEqual(true);
            });

            it('return false for invalid sex option', () => {
                expect(sut.isValid('some identifier,foo,100')).toEqual(false);
                expect(sut.isValid('some identifier,,100')).toEqual(false);
                expect(sut.isValid('some identifier,null,100')).toEqual(false);
            });

            it('return true for valid sex option', () => {
                expect(sut.isValid('some identifier,1,100')).toEqual(true);
                expect(sut.isValid('some identifier,MALE,100')).toEqual(true);
                expect(sut.isValid('some identifier,Male,100')).toEqual(true);
                expect(sut.isValid('some identifier,male,100')).toEqual(true);
                expect(sut.isValid('some identifier,2,100')).toEqual(true);
                expect(sut.isValid('some identifier,FEMALE,100')).toEqual(true);
                expect(sut.isValid('some identifier,Female,100')).toEqual(true);
                expect(sut.isValid('some identifier,female,100')).toEqual(true);
            });

            it('return false for non-numeric body weight', () => {
                expect(sut.isValid('some identifier,1,foo')).toEqual(false);
            });

            it('return true for numeric body weight', () => {
                expect(sut.isValid('some identifier,1,100')).toEqual(true);
                expect(sut.isValid('some identifier,1,1.22366548')).toEqual(true);
            });

            it('return false for non-numeric weight', () => {
                expect(sut.isValid('some identifier,1,100,foo')).toEqual(false);
            });

            it('return true for numeric body weight', () => {
                expect(sut.isValid('some identifier,1,100,300')).toEqual(true);
                expect(sut.isValid('some identifier,1,1.22366548,300.655445858')).toEqual(true);
            });

            it('return true for multiple valid lines', () => {
                expect(sut.isValid('some identifier,1,100,300\n' +
                    'some identifier,1,100,300\n' +
                    'some identifier,1,100,300')).toEqual(true);
            });

            it('ignore extra blank lines', () => {
                expect(sut.isValid('some identifier,1,100,300\n' +
                    'some identifier,1,100,300\n' +
                    'some identifier,1,100,300\n\n\n')).toEqual(true);
            });

            it('ignore extra spaces', () => {
                expect(sut.isValid('some identifier, 1 ,100,300\n' +
                    'some identifier,1,100    ,300\n' +
                    'some identifier    ,1,100,300\n\n\n')).toEqual(true);
            });

            it('return false for spaces', () => {
                expect(sut.isValid('   ')).toEqual(false);
                expect(sut.isValid('  \n ')).toEqual(false);
            });
        });

        describe('parse should', () => {
            it('return null for null', () => {
                expect(sut.parse(null)).toBeNull();
            });

            it('return null for invalid', () => {
                expect(sut.parse('some id,foo,1,3')).toBeNull();
            });

            it('return parsed request objects', () => {
                var result = sut.parse('some id,1,1,3\n some other id,2,2,4');
                expect(result).toEqual([
                    {
                        id: 'some id',
                        sex: '1',
                        bodyWeight: 1,
                        weight: 3
                    },
                    {
                        id: 'some other id',
                        sex: '2',
                        bodyWeight: 2,
                        weight: 4
                    }
                ]);
            });

            it('return parsed request objects with no weight', () => {
                var result = sut.parse('some id,1,1\n some other id,2,2');
                expect(result).toEqual([
                    {
                        id: 'some id',
                        sex: '1',
                        bodyWeight: 1,
                        weight: 0
                    },
                    {
                        id: 'some other id',
                        sex: '2',
                        bodyWeight: 2,
                        weight: 0
                    }
                ]);
            });
        });
    });

    class SutFactory {
        build(): CalculationInputParser {
            var sut;

            inject(($injector: ng.auto.IInjectorService) => {
                sut = $injector.get(CalculationInputParser.id);
            });

            return sut;
        }
    }
}
