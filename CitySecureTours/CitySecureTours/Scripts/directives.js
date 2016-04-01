/// <reference path="angular.js" />

(function () {
    var app = angular.module('tour-directives', []);

    app.directive('featuredProduct', function () {
        return {
            restrict: 'E',
            templateUrl: '/Templates/products/featuredProduct.html'
       };
    });

    app.directive('featuredCategory', function () {
        return {
            restrict: 'E',
            templateUrl: '/Templates/products/categoryProduct.html'
        };
    });

    app.directive('cartItem', function () {
        return {
            restrict: 'E',
            templateUrl: '/Templates/cart/cartItem.html'
        };
    });
})();