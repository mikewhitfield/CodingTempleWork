$(document).ready(function () {
    
    /* ==========================================================================
       Add to Cart
       ========================================================================= */
    var sum = 0;
    var kidSum = 0;
    var total = 0;

    $('.total').text(total);
    $('.click-num').text(sum);
    $('.adults .row-total').text(sum);
    $('.kids .row-total').text(sum);

    $('#adults .plus a').click(function (e) {
        e.preventDefault();

        if (sum < 5) {
            sum++;

            $('#adults .click-num').text(sum);
            $('.adults .row-total').text(sum);
        }

        if (total <= 60 ) {          
            $('.total').text(parseInt(total + 20));
            total += 20;
        }
    });

    $('#adults .minus a').click(function (e) {
        e.preventDefault();

        if (sum > 0) {           
            sum--;
           
            $('#adults .click-num').text(sum);
            $('.adults .row-total').text(sum);
        }

        if (total >= 20) {          
            $('.total').text(parseInt(total - 20));
            total -= 20;
        }
    });


    $('#kids .plus a').click(function (e) {
        e.preventDefault();

        if (kidSum < 5) {
            kidSum++;
            
            $('#kids .click-num').text(kidSum);
            $('.kids .row-total').text(kidSum);
        }

        if (total <= 70) {           
            $('.total').text(parseInt(total + 10));
            total += 10;
        }
    });

    $('#kids .minus a').click(function (e) {
        e.preventDefault();

        if (kidSum > 0) {
            kidSum--;
           
            $('#kids .click-num').text(kidSum);
            $('.kids .row-total').text(kidSum);
        }

        if (total >= 10) {                     
            $('.total').text(parseInt(total - 10));
            total -= 10;
        }
    });


    /* ==========================================================================
       Banner Img Change
       ========================================================================= */
    $('.main-img').load(function () {
        var bannerBg = $('.main-img ').attr('src'); 
        $('.banner.detail').css('background-image', 'url(' + bannerBg + ')');
    });

    /* ==========================================================================
       Navigation
       ========================================================================= */
    $('.header-wrapper header nav  li  + a ').wrapAll('<li/>');
});

