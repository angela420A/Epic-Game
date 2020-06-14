CKEDITOR.replace('editor1', { customConfig: '/Assets/Js/ckeditorconfig_Product.js' });
//Vue
Vue.component('swiper-compo', {
    template:'<li class="col-3" v-on:click="deleteUrl"><div style="border: 1px solid #999;" class="swiper-wrap"><div class="DeleteSwiper" id="DeleteSwiper"></div><div style="padding-bottom: calc(3/5 * 100%); position: relative"><div class="ImgArea"><img :src="swiper" alt="swiper" style="width: 100%; height:100%; object-fit: cover"/></div></div></div></li>',
    props: ['swiper'],
    name: 'siwper-compo',
    methods: {
        deleteUrl: function (e) {
            var url = e.path[1].querySelector('img').currentSrc;
            var index = ImgVue.swiperList.indexOf(url);
            ImgVue.swiperList.splice(index, 1);
        }
    }
})

Vue.component('screen-compo', {
    template: '<li class="col-10" v-on:click="deleteUrl"><div style="border: 1px solid #999;" class="swiper-wrap"><div class="DeleteSwiper" id="DeleteSwiper"></div><div style="padding-bottom: calc(3/5 * 100%); position: relative"><div class="ImgArea"><img :src="swiper" alt="swiper" style="width: 100%; height:100%; object-fit: cover"/></div></div></div></li>',
    props: ['swiper'],
    name: 'screen-compo',
    methods: {
        deleteUrl: function (e) {
            var url = e.path[1].querySelector('img').currentSrc;
            var index = PInfoVue.swiperList.indexOf(url);
            PInfoVue.swiperList.splice(index, 1);
        }
    }
})

var PInfo = new Vue({
    el: '#ProductInfoVue',
    data: {
        ProName: "",
        ProPrice: "",
        ProType: "",
        ProDeveloper: "",
        ProPublisher: "",
        ProContext: "",
        ProAgeRestrct: "",
        ProPrivInfo: "",
        ProPrivLink:"",
        CategoriesGroup: [],
        CategoriesText: {
            "1": "Action",
            "2": "Adventure",
            "4": "Editors",
            "8": "Puzzle",
            "16": "Racing",
            "32": "RPG",
            "64": "Shooter",
            "128": "Strategy",
            "256": "Survival",
            "512": "ControllerSupport",
            "1024": "CoOp",
            "2048": "SinglePlayer",
            "4096": "Multiplayer",
            "8192": "Windows",
            "16384": "MacOS"
        }
    },
    methods: {
        changeColor: function (event) {
            let inputTarget = event.target;
            if (inputTarget.className.includes('primary')) {
                inputTarget.setAttribute('class', 'btn btn-secondary')
            } else {
                inputTarget.setAttribute('class', 'btn btn-primary')
            }
        }
    }
})

var ImgVue = new Vue({
    el: '#app',
    data: {
        storeImage: {},
        logoImage: {},
        swiperList: ["https://i.imgur.com/LqiqP3y.jpg", "https://i.imgur.com/YflgSCT.png", "https://i.imgur.com/W0E2fcs.jpg", "https://i.imgur.com/YflgSCT.png", "https://i.imgur.com/W0E2fcs.jpg"],
        UploadList: []
    },
    methods: {
        showFile(e) {
            debugger;
            var t = e.target.files;
            var input = e.target.id;
            for (let i = 0; i < t.length; i++) {
                let item = t[i];
                let data = {
                    file: item, // 準備拿 input type="file" 的值
                    //album: album, // 若要指定傳到某個相簿，就填入相簿的 ID
                    fs: {
                        name: item.name, // input的圖檔名稱
                        thumbnail: window.URL.createObjectURL(item), // input的圖片縮圖
                        size: Math.floor(item.size * 0.001) + 'KB' // input的圖片大小
                    },
                    title: item.name, // 圖片標題
                }
                this.UploadList.push(data);
            }
            this.submit(input);
        },
        submit: function (input) {
            let settings = {
                async: false,
                crossDomain: true,
                processData: false,
                contentType: false,
                type: 'post',
                url: '/ProductManage/UploadImg',
                mimeType: 'multipart/form-data'
            };
            let array = [];
            this.UploadList.forEach(item => {
                let form = new FormData();
                form.append('image', item.file);
                form.append('title', item.title);
                form.append('description', '');
                //form.append('album', file.album); // 有要指定的相簿就加這行
                settings.data = form;
                $.ajax(settings).done(function (res) {
                    //console.log(res); // 可以看見上傳成功後回的值
                    array.push(res);
                });
            });
            this.UploadList = [];
            this.addToImgList(array, input);
        },
        addToImgList: function (array, input) {
            debugger;
            array.forEach(element => {
                switch (input) {
                    case "StoreImage":
                        this.storeImage = element;
                        break;
                    case "LogoImage":
                        this.logoImage = element;
                        break;
                    case "SwiperImage":
                        this.swiperList.push(element);
                        break;
                    case "screenShot":
                        PIntroVue.swiperList.push(element);
                        break;
                }
            })
            this.showImage(array, input);
        },
        //https://i.imgur.com/ycGq26p.jpg
        showImage: function (array, input) {
            let father = '#' + input + 'Area';
            if (input != 'SwiperImage') {
                let u = $('<div></div>').attr('class', 'ImgArea');
                $(father).append(u);
                u.attr('style', 'background-image: url("' + array[0] + '");');
            }
            //else {
            //    array.forEach(element => {
            //        let swiper = this.swiperComponent(element);
            //        $(father).append(swiper);
            //    });
            //}
        }
        //swiperComponent: function (URL) {
        //    let col = $('<li></li>').attr('class', 'col-3');
        //    let wrap = $('<div></div>').attr('class', 'swiper-wrap');
        //    let DeleteSwiper = $('<div></div>').attr('class', 'DeleteSwiper');
        //    let span1 = $('<span></span>');
        //    let span2 = $('<span></span>');
        //    let border = $('<div></div>').attr('class', 'swiper-border');
        //    let ImgArea = $('<div></div>').attr('class', 'ImgArea');
        //    col.append(wrap.append(DeleteSwiper.append(span1).append(span2)).append(border.append(ImgArea)));
        //    ImgArea.attr('style', 'background-image: url("' + URL + '");');
        //    return col;
        //}
        //< li class= "col-3" >
        //    <div style="border: 1px solid #999;" class="swiper-wrap">
        //        <div class="DeleteSwiper" id="DeleteSwiper">
        //            <span></span>
        //            <span></span>
        //        </div>
        //        <div style="padding-bottom: calc(3/5 * 100%); position: relative">
        //            <div class="ImgArea">
        //                <img src="" alt="swiper" />
        //            </div>
        //        </div>
        //    </div>
        //            </li >
    }
})

var PIntroVue = new Vue({
    el: '#ProductIntro',
    data:{
        swiperList: ["https://i.imgur.com/YflgSCT.png", "https://i.imgur.com/LqiqP3y.jpg", "https://i.imgur.com/YflgSCT.png", "https://i.imgur.com/LqiqP3y.jpg", "https://i.imgur.com/W0E2fcs.jpg"],
    },
    methods: {
        //getInfo: function () {
        //    var r = CKEDITOR.instances.editor1.getData();
        //},
        submit: function (e) {
            ImgVue.showFile(e);
        }
    }
});

var SubmitVue = new Vue({
    el: '#submitVue',
    methods: {
        createProduct: function () {
            let ProductVM = {
                ProductName: PInfo.ProName,
                Price: PInfo.ProPrice,
                ContentType : PInfo.ProType,
                Developer : PInfo.ProDeveloper,
                Publisher : PInfo.ProPublisher,
                Title: PInfo.ProContext,
                Description: CKEDITOR.instances.editor1.getData(),
                AgeRestriction : PInfo.ProAgeRestrct,
                PrivacyPolicy : PInfo.ProPrivInfo,
                PrivacyPolicyUrl: PInfo.ProPrivLink,
                ImageVM: {
                    StoreImg: ImgVue.storeImage,
                    GameLogo: ImgVue.logoImage,
                    SwiperImg: ImgVue.swiperList,
                    ScreenShots: PIntroVue.swiperList
                }
            }
            debugger;
            let settings = {
                async: false,
                crossDomain: true,
                processData: false,
                contentType: false,
                type: 'post',
                url: '/ProductManage/CreateProduct',
                dataType: 'json',
                data: JSON.stringify(ProductVM)
            };
            $.ajax(settings).done(function (res) { });
            //$.ajax({
            //    url: "/ProductManage/CreateProduct",
            //    type: "post",
            //    data: { jdata: "aa" },
            //    success: function () {
            //        alert("success");
            //    },
            //    error: function (xhr, ajaxOptions, thrownError) {
            //        console.log(xhr.status);
            //        console.log(thrownError);
            //        debugger;
            //    }


            //})
        }
    }

})