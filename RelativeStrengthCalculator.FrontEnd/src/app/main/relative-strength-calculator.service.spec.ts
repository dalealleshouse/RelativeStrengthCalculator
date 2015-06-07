module RelativeStrengthCalculator {
    'use strict';

    describe('RelativeStrengthService', () => {
        var sut: IRelativeStrengthService;
        var $httpBackend: ng.IHttpBackendService;

        beforeEach(() => {
            angular.mock.module(appName);
            var builder = new SutBuilder();
            sut = builder.sut;
            $httpBackend = builder.$httpBackend;
        });

        describe('buildRequestUrl should', () => {
            it('throw if null inputs', () => {
                expect(() => { sut.buildRequestUrl(null, 'foo'); }).toThrow();
                expect(() => { sut.buildRequestUrl('foo', null); }).toThrow();
                expect(() => { sut.buildRequestUrl(null, null); }).toThrow();
            });

            it('return a URL based on the supplied parameters', () => {
                var expected = `${sut.baseUrl}foo/bar`;
                var result = sut.buildRequestUrl('foo', 'bar');
                expect(result).toEqual(expected);
            });

            it('return a URL based on the numeric parameters', () => {
                var expected = `${sut.baseUrl}1/2`;
                var result = sut.buildRequestUrl(1, 2);
                expect(result).toEqual(expected);
            });
        });

        describe('metaData should', () => {
            it('return empty hashes until promise is resolved', () => {
                var formulas = { '1': 'formula1', '2': 'formula2' };
                var weightUnits = { '1': 'unit1', '2': 'unit2' };
                var sexes = { '1': 'Male', '2': 'Female' };

                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/formulas`).respond(formulas);
                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/weightUnits`).respond(weightUnits);
                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/sexes`).respond(sexes);

                var result = sut.metaData();
                expect(result.formulas).toEqual({});
                expect(result.weightUnits).toEqual({});
                expect(result.sexes).toEqual({});

                $httpBackend.flush(3);

                expect(result.formulas).toEqual(formulas);
                expect(result.weightUnits).toEqual(weightUnits);
                expect(result.sexes).toEqual(sexes);
            });

            it('run catch and finally', () => {
                var expected = { thenRun: false, catchRun: true, finallyRun: true };

                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/formulas`).respond(500, 'error');
                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/weightUnits`).respond({});
                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/sexes`).respond({});

                var result = sut.metaData();
                testPromise(expected, result.$promise, 3);
            });

            it('run then and finally', () => {
                var expected = { thenRun: true, catchRun: false, finallyRun: true };

                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/formulas`).respond({});
                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/weightUnits`).respond({});
                $httpBackend.expect('GET', `${sut.baseUrl}api/metadata/sexes`).respond({});

                var result = sut.metaData();
                testPromise(expected, result.$promise, 3);
            });

            afterEach(() => {
                $httpBackend.verifyNoOutstandingExpectation();
                $httpBackend.verifyNoOutstandingRequest();
            });


        });

        describe('results should', () => {
            it('return empty array until promise is resolved', () => {
                var requests: Array<ICalculatorRequest> = [
                    { id: '1', sex: 1, weight: 1, bodyWeight: 1 },
                    { id: '2', sex: 2, weight: 2, bodyWeight: 2 }
                ];

                var results: Array<ICalculatorResult> = [
                    { id: '1', sex: 1, weight: 1, bodyWeight: 1, coefficient: 1, score: 1 },
                    { id: '2', sex: 2, weight: 2, bodyWeight: 2, coefficient: 2, score: 2 }
                ];

                $httpBackend.expectPOST(sut.buildRequestUrl(1, 2), requests).respond(results);

                var result = sut.results(1, 2, requests);
                expect(result.length).toEqual(0);

                $httpBackend.flush(1);

                expect(result.length).toEqual(2);
            });

            it('run catch and finally', () => {
                var expected = { thenRun: false, catchRun: true, finallyRun: true };

                $httpBackend.expect('POST', sut.buildRequestUrl(1, 2)).respond(500, 'error');

                var result = sut.results(1, 2, [{ id: '1', sex: 1, weight: 1, bodyWeight: 1 }]);
                testPromise(expected, result.$promise, 1);
            });

            it('run then and finally', () => {
                var expected = { thenRun: true, catchRun: false, finallyRun: true };

                $httpBackend.expect('POST', sut.buildRequestUrl(1, 2)).respond([]);

                var result = sut.results(1, 2, [{ id: '1', sex: 1, weight: 1, bodyWeight: 1 }]);
                testPromise(expected, result.$promise, 1);
            });

            afterEach(() => {
                $httpBackend.verifyNoOutstandingExpectation();
                $httpBackend.verifyNoOutstandingRequest();
            });
        });

        function testPromise(expected: { thenRun: boolean; catchRun: boolean; finallyRun: boolean; }, promise: ng.IPromise<any>, flushCount: number) {
            var runResults = {
                thenRun: false,
                catchRun: false,
                finallyRun: false
            };

            promise.then(() => {
                runResults.thenRun = true;
            }).catch(() => {
                runResults.catchRun = true;
            }).finally(() => {
                runResults.finallyRun = true;
            });

            expect(runResults).toEqual({ thenRun: false, catchRun: false, finallyRun: false });

            $httpBackend.flush(flushCount);

            expect(runResults).toEqual(expected);
        }
    });

    class SutBuilder {
        sut: IRelativeStrengthService = null;
        $httpBackend: ng.IHttpBackendService = null;

        constructor() {
            angular.mock.inject(($injector: ng.auto.IInjectorService) => {
                this.sut = $injector.get(RelativeStrengthService.id);
                this.$httpBackend = $injector.get('$httpBackend');
            });
        }
    }
}
