/// <reference path="angular.js" />


(function () {

    var app = angular.module('tour', ['tour-directives']);

    app.controller('TourController', ['$scope', 'Product', function ($scope, Product) {
        // this.featuredTours = [];
        $scope.featuredTours = [];

        var that = this;

        //var request = $http.get('Products.json');
        var request = Product.all();

        request.success(function (data) {
            that.featuredTours = data;
            console.log(that.featuredTours);
        });

        request.error(function (a, b, c) {
            console.log(a);
        });
    }]);


    app.controller('CategoryController', ['$scope', 'Category', function ($scope, Category) {
        // this.featuredTours = [];
        this.featuredTours = [];

        var that = this;

        var request = Category.all();

        request.success(function (data) {
            that.featuredTours = data;
            console.log(that.featuredTours);
        });

        request.error(function (a, b, c) {
            console.log(a);
        });

        this.FilterByCat = function (type, listId) {

            $('.top-side-menu li').each(function () {
                var catId = $(this).attr('data-category');
                if (catId == listId) {
                    // alert($(this).attr('data-category') + ", " + listId);
                    $(this).addClass('highlight').siblings().removeClass('highlight');
                }
            })

            $('.map_tour_info').each(function () {
                var tourName = $(this).find('.tour-name').text();
                if (tourName != type) {
                    $(this).addClass('hidden');
                } else {
                    $(this).removeClass('hidden');
                }
            });
        }

        this.ShowAll = function (listId) {
            $('.top-side-menu li').each(function () {
                var catId = $(this).attr('data-category');
                if (catId == listId) {
                    // alert($(this).attr('data-category') + ", " + listId);
                    $(this).addClass('highlight').siblings().removeClass('highlight');
                }
            })

            $('.map_tour_info').each(function () {
                $(this).removeClass('hidden');
            });
        }

        this.FilterByPrice = function () {

            var prValue = $('#priceRanger').val();

            if (prValue != '') {
                var min = parseFloat(prValue.split('-')[0]);
                var max = parseFloat(prValue.split('-')[1]);
                var price;

                $('.map_tour_info').each(function () {
                    price = $(this).find('.big-price strong').text();
                    myPrice = parseFloat(price.substring(1, price.length));

                    if (myPrice >= min && myPrice <= max) {
                        $(this).removeClass('hidden');
                    } else {
                        // alert(min + ' ' + max + ' ' + price);
                        $(this).addClass('hidden');
                    }
                });



            } else {
                $('.map_tour_info').each(function () {
                    $(this).removeClass('hidden');
                });
            }



        }

    }]);

    app.controller('DetailController', ['$scope', 'Detail', function ($scope, Detail) {

        var params = window.location.href.split("/");
        var id = parseInt(params[params.length - 1]);

        //function getVar() {
        //    var query = window.location;
        //    var queryString = new String(query);
        //    var queryId = queryString.substr(-1)

        //    return queryId;
        //}
        //getVar();

        // this.featuredTours = [];
        this.product = {};
        this.thumbs = []

        var that = this;

        //var request = $http.get('Products.json');
        var request = Detail.find(id);

        request.success(function (data) {
            that.product = data;
            console.log(that.product);
        });

        request.error(function (a, b, c) {
            console.log(a);
        });

        //Thumbnails
        var req = Detail.findThumbs(id);

        req.success(function (info) {
            that.thumbs = info;
        });

        req.error(function (a, b, c) {
            console.log(a);
        });
    }]);

    //app.service('cartService', function () {
    //    this.cart_item = 0;
    //    var that = this;

    //    this.cartCount = function () {
    //        that.cart_item++;
    //        return cart_item;
    //        $('.cartItem').text('(' + cartService.cartCount() + ')');
    //    }

    //});

    app.controller('CartCountController', ['$scope', 'CartCount', function ($scope, CartCount) {
       // alert(CartCount.updated);

       // $('.cartItem').text('(' + CartCount.cCount + ')');

       this.addCounter = function() {
           CartCount.addCount();
       }

       this.minusCounter = function () {
           CartCount.minusCount();
       }

      
    }]);

    app.controller('CartItemController', [ '$scope', 'CartItem', function ( $scope, CartItem) {
        this.myCartItems = [];
       // this.cart_item = 0;

        
       // var cookieItem = document.cookie;
       // var cookieString = new String(cookieItem);
       // var cookieNum = cookieString.substr(-1)

       // alert(cookieNum)

        //if (isNaN(cookieNum)) {
        //    $('.cartItem').hide();
        //} else {
        //    $('.cartItem').show();
        //}

       // $('.cartItem').text('(' + cookieNum + ')');

        var that = this;
        var request;

       // alert(document.cookie);

        //Page Load - show all cart Items
        var request = CartItem.all();

        request.success(function (data) {
            that.myCartItems = data;
            console.log(that.cartItems);
        });

        request.error(function (a, b, c) {
            console.log(a);
        });

        this.AddToCart = function (productId) {
            
           // that.cart_item++;

            var totall = $('.total').text();

            cartDTO = {};
            cartDTO['Total'] = totall;
            cartDTO['ProductId'] = productId;

            console.dir(cartDTO);

            request = CartItem.create(cartDTO);

            request.success(function (data) {
                that.cartItems = data;
                console.log(that.cartItems);
            });

            request.error(function (a, b, c) {
                console.log(a);
            });

            //$('.cartItem').text('(' + that.cart_item + ')');

           // document.cookie = "cartCount=" + that.cart_item + ";domain=;path=/";
           // alert(document.cookie);

        }

        this.deleteCart = function (cartID) {
            
            //that.cart_item = parseInt(that.cartItem) - 1;

            //alert(that.cart_item);

            request = CartItem.delete(cartID);

            request.success(function (data) {
                console.log(data);
                //location.reload();

                var request = CartItem.all();

                request.success(function (data) {
                    that.myCartItems = data;
                    console.log(that.cartItems);
                });

                request.error(function (a, b, c) {
                    console.log(a);
                });

            });

            request.error(function (a, b, c) {
                console.log(a);
            });

            //$('.cartItem').text('(' + that.cart_item + ')');

            //if (isNaN(that.cart_item) ) {
            //    $('.cartItem').hide();
            //} else {
            //    $('.cartItem').show();
            //}

           // document.cookie = "cartCount=" + that.cart_item + ";domain=;path=/";
        }

    }]);


})();