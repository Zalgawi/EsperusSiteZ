/*
 * Author: Hon Min Yue
 * URL: https://codepen.io/honminyue/pen/NPLYRp?editors=1010
 * 
 * Animate the nested elements of a carousel slideshow.
 */

(function ($) {
    function doAnimations(elems) {
        var animEndEv = 'webkitAnimationEnd animationend';

        elems.each(function () {
            var $this = $(this),
                $animationType = $this.data('animation');
            $this.addClass($animationType).one(animEndEv, function () {
                $this.removeClass($animationType);
            });
        });
    }

    var $myCarousel = $('#header-carousel');
    var $firstAnimatingElems = $myCarousel.find('.item:first').find("[data-animation ^= 'animated']");

    $myCarousel.carousel();

    doAnimations($firstAnimatingElems);

    $myCarousel.carousel('pause');

    $myCarousel.on('slide.bs.carousel', function (e) {
        var $animatingElems = $(e.relatedTarget).find("[data-animation ^= 'animated']");
        doAnimations($animatingElems);
    });
})(jQuery);
