//search
var searchbar = document.querySelector('.navbar .form-control');
var navBar = document.querySelector('.navbar');
var searchnav = document.querySelector('svg');
var onoff = false;
var li = document.querySelector('.div_itemlist li');
console.log(searchbar);
searchnav.addEventListener('click', function () {
    if (onoff == false) {
        searchbar.setAttribute('style', 'display: block');
        navBar.setAttribute('style', 'width: 100%');
        onoff = true;
    }
    else if (onoff == true) {
        searchbar.setAttribute('style', 'display: none');
        navBar.setAttribute('style', 'width: initial');
        onoff = false;
    }
});
// star rating
var $star_rating = $('.star-rating .fa');

var SetRatingStar = function () {
    return $star_rating.each(function () {
        if (parseInt($star_rating.siblings('input.rating-value').val()) >= parseInt($(this).data('rating'))) {
            return $(this).removeClass('fa-star-o').addClass('fa-star');
        } else {
            return $(this).removeClass('fa-star').addClass('fa-star-o');
        }
    });
};

$star_rating.on('click', function () {
    $star_rating.siblings('input.rating-value').val($(this).data('rating'));
    return SetRatingStar();
});

SetRatingStar();
$(document).ready(function () {

});
//SHOW MORE
function SHOWMORE() {
    var dots = document.getElementById("dots");
    var moreText = document.getElementById("more");
    var btnText = document.getElementById("Btn_showmore");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "SHOW MORE";
        moreText.style.display = "none";

    } else {
        dots.style.display = "none";
        btnText.innerHTML = "SHOW LESS";
        moreText.style.display = "inline";


    }
}
//¼v¤ù¤Á´«
let lastSlideIndex = 0;
var mySwiper = new Swiper('.swiper-container', {
    direction: 'horizontal',
    loop: true,
    pagination: {
        el: '.swiper-pagination',
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    scrollbar: {
        el: '.swiper-scrollbar',
    },
    
    observer: true,
    observeParents: true,
    on: {
        init: function () {
            const self = this;
            const activeIndex = self.activeIndex;

            setTimeout(function () {
                playPauseVideo(self, self.activeIndex, "play");
            }, 1000);

            lastSlideIndex = activeIndex;
        },
        slideNextTransitionEnd: function () {
            const self = this;
            const activeIndex = self.activeIndex;

            playPauseVideo(self, lastSlideIndex, "pause");
            playPauseVideo(self, activeIndex, "play");

            lastSlideIndex = activeIndex;
        },
        slidePrevTransitionEnd: function () {
            const self = this;
            const activeIndex = self.activeIndex;

            playPauseVideo(self, lastSlideIndex, "pause");
            playPauseVideo(self, activeIndex, "play");

            lastSlideIndex = activeIndex;
        }
    }
});


function postMessageToPlayer(player, command) {
    if (player == null || command == null) return;
    player.contentWindow.postMessage(JSON.stringify(command), "*");
}

function playPauseVideo(swiper, activeIndex, control) {
    var currentSlide, player;
    currentSlide = swiper.slides[activeIndex];
    player = currentSlide.querySelector('iframe');
    switch (control) {
        case "play":
            postMessageToPlayer(player, {
                "event": "command",
                "func": "mute"
            });
            postMessageToPlayer(player, {
                "event": "command",
                "func": "playVideo"
            });
            break;
        case "pause":
            postMessageToPlayer(player, {
                "event": "command",
                "func": "pauseVideo"
            });
            break;
    }
}