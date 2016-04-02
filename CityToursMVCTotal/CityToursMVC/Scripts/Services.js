/// <reference path="angular.js" />

(function () {
    //Factory

    angular.module("tour").factory("Detail", function DetailFactory($http) {
        return {
            all: function () {
                return $http({ method: "get", url: 'http://localhost:52431/Products/GetAll/' });
            },
            find: function (id) {
                return $http({ method: "GET", url: 'http://localhost:52431/Products/FindById/' + id });
            },
            findThumbs: function (id) {
                return $http({ method: "GET", url: 'http://localhost:52431/ProductImages/FindThumbs/' + id });
            }
        };
    });


    angular.module("tour").factory("Category", function CategoryFactory($http) {
        return {
            all: function () {
                return $http({ method: "get", url: 'http://localhost:52431/Products/GetAll/' });
            }
        };
    });

    angular.module("tour").factory("Product", function ProductFactory($http) {
        return {
            all: function () {
                return $http({ method: "get", url: 'http://localhost:52431/Featured/GetAll/' });
            },
            
            find: function (id) {
                return $http({ method: "GET", url: 'http://localhost:51737/Api/products/findbyid/' + id });
            },
            findByName: function (name) {
                return $http({ method: "Get", url: 'http://localhost:51737/Api/products/FindByName?name=' + name });
            },
            create: function (productInfo) {
                return $http({ method: "POST", url: 'http://localhost:51737/Api/products/create/', data: JSON.stringify(productInfo) });
            },

            delete: function (id) {
                return $http({ method: "DELETE", url: 'http://localhost:51737/Api/products/deletebyId/' + id });
            },

            update: function (prod, id) {
                return $http({ method: "PUT", url: 'http://localhost:51737/Api/products/updatebyId/' + id, data: prod });
            }
        };
    });

    angular.module("tour").factory("CartItem", function CartItemFactory($http) {
        return {
            all: function () {
                return $http({ method: "GET", url: 'http://localhost:52431/CartItems/GetAll' });
            },

            create: function (productInfo) {
                return $http({ method: "POST", url: 'http://localhost:52431/CartItems/create/', data: JSON.stringify(productInfo) });
            },

            delete: function (id) {
                return $http({ method: "DELETE", url: 'http://localhost:52431/CartItems/deletebyId/' + id });
            }
        };
    });

    angular.module("tour").service("CartCount", function CartService() {
        this.cCount = 1;
        

        var that = this;

       // alert(this.cCount);

        this.addCount = function () {
            that.cCount = that.cCount + 1;
            $('.cartItem').text('(' + that.cCount + ')');

            //alert(that.cCount);

           // return that.cCount;
        }

        this.minusCount = function () {
            that.cCount = that.cCount - 1;
            $('.cartItem').text('(' + that.cCount + ')');

            //that.updated = that.cCount;
        }
       
        this.updated = that.cCount;

        //$('.cartItem').text('(' + this.cCount + ')');

    });

})();