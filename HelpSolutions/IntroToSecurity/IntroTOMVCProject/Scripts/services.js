/// <reference path="angular.js" />


(function () {
    //Factory
    angular.module("store").factory("Product", function ProductFactory($http) { // .factory (nameOfTable, function
        return {
            all: function () {
                return $http({ method: "GET", url: 'http://localhost:51737/Api/products/getall/' });
            },

            find: function (id) {
                return $http({ method: "GET", url: 'http://localhost:51737/Api/products/findbyid/' + id });
            },
            findByName: function(name){
                return $http({ method: "Get", url: 'http://localhost:51737/Api/products/FindByName?name=' + name  });
            },
            create: function (productInfo) {
                return $http({ method: "POST", url: 'http://localhost:51737/Api/products/create/', data: JSON.stringify(productInfo) });
            },

            findByCategoryId: function (id, categoryId){
                return $http({ method: "GET", url: 'http://localhost:51737/FindByCategoryId?id=' +id + "&categoryId=" + categoryId });
            },

            delete: function (id) {
                return $http({ method: "DELETE", url: 'http://localhost:51737/Api/products/deletebyId/' + id });
            },

            update: function (prod, id) {
                return $http({ method: "PUT", url: 'http://localhost:51737/Api/products/updatebyId/' + id, data:prod });
            }
        };
    });

    //Provider
    //angular.module("store").provider("Product", function ProductProvider() {
    //    this.id = 1

    //    this.setId = function (newId) {
    //        id = newId;
    //    }

    //    this.$get = function($http) {
    //        return {
    //            setId: function (newId) {
    //                id = newId;
    //            }, 
    //            all: function () {
    //                return $http({ method: "GET", url: 'http://localhost:51737/Api/products/' });
    //            },

    //            find: function (id) {
    //                return $http({ method: "Get", url: 'http://localhost:51737/Api/products/' + id });
    //            }
    //        };
    //    };
    //});

})();