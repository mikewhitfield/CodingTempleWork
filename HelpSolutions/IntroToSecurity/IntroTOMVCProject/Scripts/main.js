//window.onload = function () {

    //Get the products
    // var products = document.getElementsByClassName('product'); //preivous way to grab all product article

    //var filters = {
    //    shirtSize : 0,
    //    colors: [],
    //    priceRange: ''
    //};

    //Radio Button
    //var rbShirtSize = document.getElementsByName("rbSize"); //Grabs element by input name
    ////Checkboxes
    //var chx = document.getElementsByName('cbColors');
    ////Price Rang
    //var ddlPriceRange = document.getElementById('ddlPriceRange');

    //PopUp
    //var overviewButtons = document.querySelectorAll('input[name=overviewButtons]');
    //(same thing) var overviewButtons = document.getElementsByName('overviewButtons');

    //popoCLose Button
    //var popupClose = document.querySelector('.popup-close');

    //Click When click on Overlay
    //var overlay = document.querySelector('.popup-overlay')




    //function getVisibleProducts() {
    //    var products = document.getElementsByClassName('product');
    //    var visible = [];
    //    for (var i = 0; i < products.length; i++) {
    //        if (products[i].style.display == 'block') {
    //            visible.push(products[i]);
    //        }
    //    }
    //    return visible;
    //}

    //functions
    //function shirtSzeClick() {
    //    var products = getVisibleProducts(); //only

    //   // var value = this.value;
    //    var value = 0;

    //    for (var u = 0; u < rbShirtSize.length; u++) {
    //        if (rbShirtSize[u].checked == true) {
    //            value = rbShirtSize[u].value;
    //            break;
    //        }
    //    }


    //    for (var x = 0; x < products.length; x++) {
    //        var shirtSizes = products[x].children[4].innerText.split(",");

    //        var yes = false; //sets the value to false so that we can check if one of the values match, and make true later

    //        for (var y = 0; y < shirtSizes.length; y++) {
    //            if (shirtSizes[y] == value) { // check if 1 of the values are true
    //                yes = true; //if it is - then the yes is true
    //            }
    //        }

    //        if (yes == true) { // if yes is true - then the one of the values for the innerText for shirtSize is true
    //            products[x].style.display = "block";
    //        } else {
    //            products[x].style.display = "none";
    //        }
    //    }

    //    filters.shirtSize = value;
    //}

    //function colorsClick() {
    //    var products = getVisibleProducts();

    //    //var chkVal = this.value;
    //    var colors = [];

    //    for (var y = 0; y < chx.length; y++) {
    //        if (chx[y].checked == true) {
    //            colors.push(chx[y].value)
    //        }
    //    }

    //    console.log(colors);
    //    if (colors.length > 0) {

    //        for (var z = 0; z < products.length; z++) {
    //            var shirtColors = products[z].children[3].innerText.split(',');

    //            var either = false; //Has to be reset for each product

    //            for (var c = 0; c < shirtColors.length; c++) {
    //                for (var v = 0; v < colors.length; v++) {
    //                    if (shirtColors[c] == colors[v]) {
    //                        either = true;
    //                        console.log(shirtColors[c] + ' ' + colors[v]);
    //                    }
    //                }
    //            }

    //            if (either == true) { // if yes is true - then the one of the values for the innerText for shirtSize is true
    //                products[z].style.display = "block";
    //            } else {
    //                products[z].style.display = "none";
    //            }
    //        }

    //    }

    //    //else {
    //        //for (var d = 0; d < products.length; d++) {
    //           // products[d].style.display = "inline";
    //       // }
    //    // }

    //    filters.colors = colors;
    //}

    //function priceRangeChange() {
    //   // var min = parseFloat(ddlPriceRange.value.split('-')[0]); //split: divides string up by specified delimiter (, or -)
    //    //var max = parseFloat(ddlPriceRange.value.split('-')[1]);


    //    if (ddlPriceRange.value != '') {
    //        var products = getVisibleProducts();

    //        var min = parseFloat(ddlPriceRange.value.split('-')[0]);
    //        var max = parseFloat(ddlPriceRange.value.split('-')[1]);

    //        for (var i = 0; i < products.length; i++) {
    //            var price = products[i].children[2].children[0].innerText;
    //            price = parseFloat(price.substring(1, price.length)); //if the price returns '$4.99' => that value is an string array, substring start at the value after the $ so 1

    //            if (price >= min && price <= max) {
    //                products[i].style.display = "block";
    //            } else {
    //                products[i].style.display = "none";
    //            }
    //        }
    //    }
    //    else {
    //        for (var d = 0; d < products.length; d++) {
    //            products[d].style.display = "block";
    //        }
    //    }

    //    filters.priceRange = ddlPriceRange.value;
    //}

    ////Radio Buttons
    //for (var i = 0; i < rbShirtSize.length; i++) {
    //    rbShirtSize[i].onclick = shirtSzeClick;
    //}

    ////Checkbox Button
    //for (var i = 0; i < chx.length; i++) {
    //    chx[i].onclick = colorsClick;
    //}

    ////Drop down Buttons
    //ddlPriceRange.onchange = priceRangeChange;



    /*
    for (var i = 0; i < overviewButtons.length; i++) {
        overviewButtons[i].onclick = function () {

            var popup = document.getElementById('popup');
            var product = this.parentElement.parentElement;

            var popArticle = popup.children[1].children[0];

            //image
            popArticle.children[0].children[0].src = product.children[0].children[0].src;

            //product name
            popArticle.children[1].children[0].innerText = product.children[1].children[0].innerText;

            //product price
            popArticle.children[2].children[0].innerText = product.children[2].children[0].innerText;

            //product color
            popArticle.children[3].innerText = product.children[3].innerText;

            //product size
            popArticle.children[4].innerText = product.children[4].innerText;
           
            //Function
            function closePop() {
                popup.style.display = "none";
            }

            popupClose.onclick = closePop;

            overlay.onclick = closePop;

            popup.style.display = "block";
        }
    }
    */



    //Function
    //function closePop() {
    //    var popup = document.getElementById('popup');
    //    popup.style.display = "none";
    //}

    //popupClose.onclick = closePop;

    //overlay.onclick = closePop;

    //popup.style.display = "block";




//};