CKEDITOR.replace('editor1', { customConfig: '/Assets/Js/ckeditorconfig_Product.js' });
//Vue
Vue.component('swiper-compo', {
    template: '<li class="col-3" v-on:click="deleteUrl"><div style="border: 1px solid #999;" class="swiper-wrap"><div class="DeleteSwiper" id="DeleteSwiper"></div><div style="padding-bottom: calc(3/5 * 100%); position: relative"><div class="ImgArea"><img :src="swiper" alt="swiper" style="width: 100%; height:100%; object-fit: cover"></div></div></div></li>',
    props: ['swiper'],
    name: 'siwper-compo',
    methods: {
        deleteUrl: function (e) {
            var url = e.path[1].querySelector('img').currentSrc;
            var index = ImgVue.swiperList.indexOf(url);
            ImgVue.swiperList.splice(index, 1);
        }
    }
});

Vue.component('screen-compo', {
    template: '<li class="col-10" v-on:click="deleteUrl"><div style="border: 1px solid #999;" class="swiper-wrap"><div class="DeleteSwiper" id="DeleteSwiper"></div><div style="padding-bottom: calc(3/5 * 100%); position: relative"><div class="ImgArea"><img :src="swiper" alt="swiper" style="width: 100%; height:100%; object-fit: cover"></div></div></div></li>',
    props: ['swiper'],
    name: 'screen-compo',
    methods: {
        deleteUrl: function (e) {
            var url = e.path[1].querySelector('img').currentSrc;
            var index = PInfoVue.swiperList.indexOf(url);
            PInfoVue.swiperList.splice(index, 1);
        }
    }
});

Vue.component('media-compo', {
    template:
        '<div class="col-2">'
        + '<div class="card">'
        + '<div class= "card-header row justify-content-center">'
        + '<label>{{medias.Community}}</label>'
        + '</div>'
        + '<div class="card-body justify-content-center align-content-center row" style="height:103.86px">'
        + '<a :href="medias.URL"><i :class="medias.Icon" style="font-size:40px"></i></a>'
        + '</div>'
        + '<div class="card-footer justify-content-center row">'
        + '<div class="btn btn-outline-warning" v-on:click="deleteSM" :id="medias.URL">Delete</div>'
        + '</div>'
        + '</div>'
        + '</div>',
    props: ['medias'],
    name: 'screen-compo',
    methods: {
        deleteSM: function (e) {
            var url = e.target.id;
            var index = SocialMediaVue.MediaList.findIndex(element => element.URL == url);
            debugger;
            SocialMediaVue.MediaList.splice(index, 1);
        }
    }
});

var PInfo = new Vue({
    el: '#ProductInfoVue',
    data: {
        ProName: "Mafia: Trilogy",
        ProPrice: "1799",
        ProType: "Game",
        ProDeveloper: "Hangar 13",
        ProPublisher: "2K",
        ProContext: "Play all three crime dramas in the Mafia franchise in glorious ultra HD detail, including the built from the ground up, faithfully reimagined edition of the critically acclaimed original, Mafia.",
        ProAgeRestrct: "14",
        ProPrivInfo: "© 2020 TAKE-TWO INTERACTIVE SOFTWARE, INC. DEVELOPED BY HANGAR 13. MAFIA, TAKE-TWO INTERACTIVE SOFTWARE, 2K, HANGAR 13, AND THEIR RESPECTIVE LOGOS ARE ALL TRADEMARKS AND/OR REGISTERED TRADEMARKS OF TAKE-TWO INTERACTIVE SOFTWARE, INC. THE RATINGS ICON IS A TRADEMARK OF THE ENTERTAINMENT SOFTWARE ASSOCIATION. ALL OTHER MARKS ARE PROPERTY OF THEIR RESPECTIVE OWNERS. ALL RIGHTS RESERVED.",
        ProPrivLink: "https://www.take2games.com/privacy",
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
});

var ImgVue = new Vue({
    el: '#app',
    data: {
        storeImage: "",
        logoImage: "",
        swiperList: [],
        UploadList: []
    },
    methods: {
        showFile(e) {
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
            debugger;
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
    }
});

var PIntroVue = new Vue({
    el: '#ProductIntro',
    data: {
        swiperList: [],
    },
    methods: {
        submit: function (e) {
            ImgVue.showFile(e);
        }
    }
});

var SocialMediaVue = new Vue({
    el: "#SocialMediaVue",
    data: {
        MediaList: [],
        Media: "youtube",
        MediaUrl: "",
        MediaIcon: {
            youtube: "fab fa-youtube",
            facebook: "fab fa-facebook",
            twitter: "fab fa-twitter",
            instagram: "fab fa-instagram",
            twitch: "fab fa-twitch",
            discord: "fab fa-discord",
            other: "fas fa-globe"
        }
    },
    methods: {
        AddNewMedia: function (e) {
            var id = $('#MediaType').val();
            debugger;
            let SM = {
                Community: this.Media,
                URL: this.MediaUrl,
                Icon: this.MediaIcon[this.Media]
            }
            this.MediaUrl = "";
            this.MediaList.push(SM);
        }
    }
});

var SpecVue = new Vue({
    el: '#SpecVue',
    data: {
        OSType: "Win",
        spec: [
            {
                OS: "TBC",
                CPU: "",
                GPU: "",
                Processor: "TBC",
                RAM: "",
                Memory: "TBC",
                Storage: "",
                GraphiceCard: "",
                HDD: "",
                DirectX: "",
                Addtional_Feature: "",
                Type: 0
            },
            {
                OS: "",
                CPU: "",
                GPU: "",
                Processor: "",
                RAM: "",
                Memory: "",
                Storage: "",
                GraphiceCard: "",
                HDD: "",
                DirectX: "",
                Addtional_Feature: "",
                Type: 1
            },
            {
                OS: "",
                CPU: "",
                GPU: "",
                Processor: "",
                RAM: "",
                Memory: "",
                Storage: "",
                GraphiceCard: "",
                HDD: "",
                DirectX: "",
                Addtional_Feature: "",
                Type: 2
            },
            {
                OS: "",
                CPU: "",
                GPU: "",
                Processor: "",
                RAM: "",
                Memory: "",
                Storage: "",
                GraphiceCard: "",
                HDD: "",
                DirectX: "",
                Addtional_Feature: "",
                Type: 3
            }
        ]
    }
});

var SubmitVue = new Vue({
    el: '#submitVue',
    methods: {
        createProduct: function () {
            let ProductVM = {
                ProductName: PInfo.ProName,
                Price: PInfo.ProPrice,
                ContentType: PInfo.ProType,
                Category: this.getCat(),
                Developer: PInfo.ProDeveloper,
                Publisher: PInfo.ProPublisher,
                Title: PInfo.ProContext,
                Description: this.transformHtml(CKEDITOR.instances.editor1.getData()),
                AgeRestriction: PInfo.ProAgeRestrct,
                PrivacyPolicy: PInfo.ProPrivInfo,
                PrivacyPolicyUrl: PInfo.ProPrivLink,
                ImageVM: {
                    StoreImg: ImgVue.storeImage,
                    GameLogo: ImgVue.logoImage,
                    SwiperImg: ImgVue.swiperList,
                    ScreenShots: PIntroVue.swiperList
                },
                SMVM: this.transformMedia(),
                SPVM: SpecVue.spec

            }

            $.ajax({
                url: "/ProductManage/CreateProduct",
                type: "post",
                data: { jdata: JSON.stringify(ProductVM) },
                success: function () {
                    window.location.href = "/ProductManage/Index"
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                }
            })
        },
        getCat: function () {
            let res = 0;
            PInfo.CategoriesGroup.forEach(el => {
                res += parseInt(el);
            })
            return res;
        },
        transformHtml: function (str) {
            let s = str.replace(/</g, '&lt;').replace(/>/g, '&gt;');
            return s;
        },
        transformMedia: function () {
            let array = [];
            SocialMediaVue.MediaList.forEach(element => {
                let obj = {};
                obj.Community = element.Community;
                obj.URL = element.URL;
                array.push(obj);
            });
            return array;
        }
    }
});