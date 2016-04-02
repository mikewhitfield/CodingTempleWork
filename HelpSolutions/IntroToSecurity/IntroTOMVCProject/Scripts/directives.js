/// <reference path="angular.js" />

(function () {
    var app = angular.module('store-directives', []);


    app.directive('productSize', function () {
        return {
            restrict: 'E',
            templateUrl: 'templates/filters/productSize.html'
        };

    });

    app.directive('productColor', function () {
        return {
            restrict: 'E',
            templateUrl: 'templates/filters/productColor.html'
        };

    });

    app.directive('productReview', function () {
        return {
            restrict: 'E',
            templateUrl: 'templates/products/productReview.html',
            scope: {
                product: '='
            },
            controller: function ($scope) {
                $scope.review = {};

                $scope.addReview = function () {
                    $scope.product.reviews.push($scope.review)
                    $scope.review = {};
                }
            }
           // controllerAs: 'review'
        };
    });

    app.directive('productTemplate', function () {
        return {
            restrict: 'E',
            templateUrl: 'templates/products/productTemplate.html',
            scope: {
                product: '=',
                store: '='
            },
            controller: function ($scope) {

            },
            link: function ($scope, $element) {
                $element[0].parentElement.onmouseover = function () {
                    this.style.boxShadow = "0 3px 10px #1d3548";
                };

                $element[0].parentElement.onmouseout = function () {
                    this.style.boxShadow = "0 0 6px #3f5e78";
                };
            }
        };

    });

})();