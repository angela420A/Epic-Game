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
//影片切換
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
//收藏庫
let btns = document.querySelectorAll('.btn_love');
btns.forEach(btn => {
    btn.addEventListener('click', Wish);
});
function Wish() {
    let productID = this.id;
    let redirectTo = "Product";
    let span = this.getElementsByClassName('fa-heart')[0];
    let className = span.getAttribute('class');
    let data = {
        ProductID: productID,
        redirectTo: redirectTo
    }
    $.ajax({
        url: "/WishList/ChangeWish",
        type: "post",
        data: { jdata: JSON.stringify(data) },
        success: function () {
            if (className.includes('far')) {
                span.setAttribute('class', 'fas fa-heart');
            } else {
                span.setAttribute('class', 'far fa-heart');
            }
        },
        error: function () {
            alert("Please Login !!!");
        }
    });
}
//comment
var connent = new Vue({
    el: "#exampleModal",
    data: {
        title: "",
        content: "",
        rank: 0
    },
    methods: {
        upload: function (e) {

            let object = {
                Comment_Title: this.title,
                Comment_ProductID: e.target.id,
                Comment_Date: "",
                Comment_Description: this.content,
                Comment_Rank: this.rank
            }
            $.ajax({
                url: "/Product/CreateComment",
                type: "post",
                data: { jdata: JSON.stringify(object) },

                //以動態生成的方式，更新目前在頁面上的評論
                success: function (data) {                 
                    let items = document.querySelectorAll(".grading_padding");
                    for (let i = 0; i < 3; i++ && i < items.length - 1) {                     
                        items[i].querySelector('.comment_title').innerHTML = data[i].Comment_Title;
                        items[i].querySelector('#commAuthor').innerHTML = data[i].Comment_UserName;
                        items[i].querySelector('.autor_card_date').innerHTML = data[i].Comment_Date;
                        items[i].querySelector('#commContent').innerHTML = data[i].Comment_Description ;
                    };
                    //關掉model
                    $('#exampleModal').modal('hide');
                },
                error: function () {
                    alert("Please Login!!!");

                }
            });
        }
    }
});

if (comment != null) {
    connent.title = comment.Comment_Title;
    connent.content = comment.Comment_Description;
}

//====================================以下收尋功能==================================

var search = document.querySelector(".searchArea")
search.addEventListener('keydown', function (event) {

    if (event.keyCode == 13) {
        let userinput = search.value;
        let h = "/Home/Search/" + userinput;
        window.location.href = h;
    }
});

//====================================以上收尋功能==================================