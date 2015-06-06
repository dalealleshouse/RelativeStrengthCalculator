module RelativeStrengthCalculator {
    'use strict';

    export class Thing {
        rank: number;
        title: string;
        url: string;
        description: string;
        logo: string;

        constructor(title: string, url: string, description: string, logo: string) {
            this.title = title;
            this.url = url;
            this.description = description;
            this.logo = logo;
            this.rank = Math.random();
        }
    }

    export interface IMainScope extends ng.IScope {
        awesomeThings: Thing[]
    }

    export class MainCtrl {
        constructor($scope: IMainScope) {
            var awesomeThings = [
                {
                    'title': 'AngularJS',
                    'url': 'https://angularjs.org/',
                    'description': 'HTML enhanced for web apps!',
                    'logo': 'angular.png'
                },
                {
                    'title': 'BrowserSync',
                    'url': 'http://browsersync.io/',
                    'description': 'Time-saving synchronised browser testing.',
                    'logo': 'browsersync.png'
                },
                {
                    'title': 'GulpJS',
                    'url': 'http://gulpjs.com/',
                    'description': 'The streaming build system.',
                    'logo': 'gulp.png'
                },
                {
                    'title': 'Jasmine',
                    'url': 'http://jasmine.github.io/',
                    'description': 'Behavior-Driven JavaScript.',
                    'logo': 'jasmine.png'
                },
                {
                    'title': 'Karma',
                    'url': 'http://karma-runner.github.io/',
                    'description': 'Spectacular Test Runner for JavaScript.',
                    'logo': 'karma.png'
                },
                {
                    'title': 'Protractor',
                    'url': 'https://github.com/angular/protractor',
                    'description': 'End to end test framework for AngularJS applications built on top of WebDriverJS.',
                    'logo': 'protractor.png'
                },
                {
                    'title': 'Angular Material Design',
                    'url': 'https://material.angularjs.org/#/',
                    'description': 'The Angular reference implementation of the Google\'s Material Design specification.',
                    'logo': 'angular-material.png'
                },
                {
                    'title': 'Less',
                    'url': 'http://lesscss.org/',
                    'description': 'Less extends the CSS language, adding features that allow variables, mixins, functions and many other techniques.',
                    'logo': 'less.png'
                },
                {
                    'title': 'TypeScript',
                    'url': 'http://www.typescriptlang.org/',
                    'description': 'TypeScript, a typed superset of JavaScript that compiles to plain JavaScript.',
                    'logo': 'typescript.png'
                }
            ];

            $scope.awesomeThings = new Array<Thing>();

            awesomeThings.forEach((awesomeThing: Thing) => {
                $scope.awesomeThings.push(awesomeThing);
            });
        }
    }

    angular.module(appName).controller('MainCtrl', MainCtrl);
}
