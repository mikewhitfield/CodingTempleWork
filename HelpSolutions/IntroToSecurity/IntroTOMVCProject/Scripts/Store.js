/// <reference path="angular.js" />


// Module  - same thing as a namespace
// Each namesace has a classe (controller)
// Each Controller has methods and properties
// Directives connect HMTL and Angular > Module > Controller(anything starts with 'ng-'
//Expresions (anthing inbetween the {{ and }}
// So ---
// Modules have Controllers, Controllers have methods & properties
// Namespaces have Classes, clases have methods and properties

(function () {

    var app = angular.module("store", ['store-directives', 'ngRoute']);
    //var app = angular.module("store", ['store-directives', 'ngRoute', 'Product']) // Provider
    //                        .config(function (ProductProvider) {
    //                            ProductProvider.setId(1);
    //                        });

    //app.controller('StoreController', function (Product) { // Controller - is a class, the $http is baked in to angular, to use it use []
     app.controller('StoreController', function (Product) {

        this.products = [];
        this.overviewProduct = {};

        var that = this;

        //var request = $http.get('products.json');
        //var request = $http.get('http://localhost:51737/Api/products/');

         //var request = Product.all(); // Facotry
         // var request = Product.findByName("nice shirt"); //Factory
        var request = Product.create({
            ProductName: "TestCreation",
            Price: 99.99,
            ImageUrl: "",
            Color: "",
            ShirtSize: ""
        });
        
        // Product.setId(1); goes with Provider 1
        // var request = Product.find(); // Provider1
         //var request = Product.all(); //Provider2

        request.success(function (data) {
            that.products = data;
        });

        request.error(function (a, b, c) { // a reurns nothing , b returns status code, c returns error message object
            console.log(a)
        });

        this.overviewClick = function (product) {
            this.overviewProduct = product;

            var popup = document.getElementById('popup');
            popup.style.display = 'block';
            // console.dir(this.overviewProduct);
        }

        this.closePopup = function () {
            var popup = document.getElementById('popup');
            popup.style.display = "none";
        }

    });

    app.controller("PanelController", function () {
        this.tab = 1;

        this.selectTab = function (tabNum) {
            this.tab = tabNum;
        };

        this.isSelected = function (tabNum) {
            return this.tab === tabNum;
        };

        this.getIndex = function (array, value) {
            var index = 0;
            for (var i = 0; i < array.length; i++) {
                if (array[i] === value) {
                    index = i;
                    break;
                }
            }
            return index;
        };
    });

    app.controller("FilterController", function () {
        this.filters = {
            shirtSize: 0,
            colors: [],
            priceRange: ''
        };

        this.filterColors = ["white", "black", "grey", "pink"];
        this.filterSize = ["small", "medium", "large"];

        //Radio Button
        var rbShirtSize = document.getElementsByName("rbSize"); //Grabs element by input name

        //Checkboxes
        var chx = document.getElementsByName('cbColors');
        //Price Rang
        var ddlPriceRange = document.getElementById('ddlPriceRange');

        this.shirtSzeClick = function (sortSiz) {
            //var products = getVisibleProducts(); //only
            var products = document.getElementsByClassName('product');

            // var value = this.value;
            var value = sortSiz;


            for (var x = 0; x < products.length; x++) {
                var shirtSizes = products[x].children[4].textContent.replace(/"/g, '').replace('[', '').replace(']', '').split(",");

                console.log(shirtSizes);

                var yes = false; //sets the value to false so that we can check if one of the values match, and make true later

                for (var y = 0; y < shirtSizes.length; y++) {
                    if (shirtSizes[y] == value) { // check if 1 of the values are true
                        console.log(value);
                        yes = true; //if it is - then the yes is true
                    }
                }

                if (yes == true) { // if yes is true - then the one of the values for the innerText for shirtSize is true
                    products[x].style.display = "block";
                } else {
                    products[x].style.display = "none";
                }
            }

            this.filters.shirtSize = value;
        }

        this.colorsClick = function () {

            var products = document.getElementsByClassName('product');


            var colors = [];

            for (var y = 0; y < chx.length; y++) {
                if (chx[y].checked == true) {
                    colors.push(chx[y].value)
                }
            }

            if (colors.length > 0) {

                for (var z = 0; z < products.length; z++) {
                    var shirtColors = products[z].children[0].children[3].innerText.replace(/\"|\[|\]/g, '').split(',');
                    console.log(shirtColors);

                    var either = false; //Has to be reset for each product

                    for (var c = 0; c < shirtColors.length; c++) {
                        for (var v = 0; v < colors.length; v++) {
                            if (shirtColors[c] == colors[v]) {
                                either = true;
                                console.log(shirtColors[c] + ' ' + colors[v]);
                            }
                        }
                    }

                    if (either == true) { // if yes is true - then the one of the values for the innerText for shirtSize is true
                        products[z].style.display = "block";
                    } else {
                        products[z].style.display = "none";
                    }
                }

            } else {
                for (var d = 0; d < products.length; d++) {
                    products[d].style.display = "inline";
                }
            }
            this.filters.colors = colors;
        }

        this.priceRangeChange = function () {
            if (ddlPriceRange.value != '') {
                var products = document.getElementsByClassName('product');

                var min = parseFloat(ddlPriceRange.value.split('-')[0]);
                var max = parseFloat(ddlPriceRange.value.split('-')[1]);

                for (var i = 0; i < products.length; i++) {
                    var price = products[i].children[2].children[0].innerText;
                    price = parseFloat(price.substring(1, price.length)); //if the price returns '$4.99' => that value is an string array, substring start at the value after the $ so 1

                    if (price >= min && price <= max) {
                        products[i].style.display = "block";
                    } else {
                        products[i].style.display = "none";
                    }
                }
            }
            //else {
            //    for (var d = 0; d < products.length; d++) {
            //        products[d].style.display = "block";
            //    }
            //}

            this.filters.priceRange = ddlPriceRange.value;
        }

    });

    //var shirts = [
    //    {
    //        imageurl: "img/shirt.jpg",
    //        productname: "nice shirt",
    //        price: 8,
    //        color: ["grey", "black"],
    //        shirtsize: ["small", "large"],
    //        canoverview: false,
    //        colortab: 1,
    //        shirtsizetab: 1,
    //        reviews: [
    //            {
    //                stars: 5,
    //                body: "best show",
    //                author: "mw@abc.com"
    //            }
    //        ]
    //    },
    //    {
    //        imageurl: "img/shirt1.jpg",
    //        productname: "my shirt",
    //        price: 18,
    //        color: ["white", "pink"],
    //        shirtsize: ["medium", "large"],
    //        canoverview: false,
    //        colortab: 1,
    //        shirtsizetab: 1,
    //        reviews: []
    //    },
    //    {
    //        imageurl: "img/shirt3.jpg",
    //        productname: "ice shirt",
    //        price: 8,
    //        color: ["pink", "black"],
    //        shirtsize: ["large"],
    //        canoverview: false,
    //        colortab: 1,
    //        shirtsizetab: 1,
    //        reviews: []
    //    },
    //    {
    //        imageurl: "img/shirt4.jpg",
    //        productname: "price shirt",
    //        price: 80,
    //        color: ["grey", "pink"],
    //        shirtsize: ["medium"],
    //        canoverview: false,
    //        colortab: 1,
    //        shirtsizetab: 1,
    //        reviews: []
    //    },
    //    {
    //        imageurl: "img/shirt5.jpg",
    //        productname: "cool shirt",
    //        price: 120,
    //        color: ["black"],
    //        shirtsize: ["large"],
    //        canoverview: false,
    //        colortab: 1,
    //        shirtsizetab: 1,
    //        reviews: []
    //    },
    //    {
    //        imageurl: "img/shirt6.jpg",
    //        productname: "fresh shirt",
    //        price: 176,
    //        color: ["white"],
    //        shirtsize: ["small"],
    //        canoverview: false,
    //        colortab: 1,
    //        shirtsizetab: 1,
    //        reviews: []
    //    }
    //];
   // console.log(JSON.stringify(shirts));
})();