﻿//輸入框
var Proto = new Vue({
    el: '#activityitem',
    data: {
        ProTitle: obj.Title,
        ProName: obj.ProductName,
        ProContext: obj.Content,
        DueDate: obj.Time,
    }
});

//Vue.component('swiper-compo', {
//    template: '<li class="col-3" v-on:click="deleteUrl"><div style="border: 1px solid #999;" class="swiper-wrap"><div class="DeleteSwiper" id="DeleteSwiper"></div><div style="padding-bottom: calc(3/5 * 100%); position: relative"><div class="ImgArea"><img :src="swiper" alt="This file is not a picture." style="width: 100%; height:100%; object-fit: cover"></div></div></div></li>',
//    props: ['swiper'],
//    name: 'siwper-compo',
//    methods: {
//        deleteUrl: function (e) {
//            var url = e.path[1].querySelector('img').currentSrc;
//            var index = ImgVue.swiperList.indexOf(url);
//            ImgVue.swiperList.splice(index, 1);
//        }
//    }
//});
//圖片
var ImgVue = new Vue({
    el: '#app',
    data: {
        logoImage: obj.Picture,
        UploadImg: {}
    },
    methods: {
        showFile(e) {
            let item = e.target.files[0];
            let data = {
                file: item, // 準備拿 input type="file" 的值
                //album: album, // 若要指定傳到某個相簿，就填入相簿的 ID
                fs: {
                    name: item.name, // input的圖檔名稱
                    //thumbnail: window.URL.createObjectURL(item), // input的圖片縮圖
                    size: Math.floor(item.size * 0.001) + 'KB' // input的圖片大小
                },
                title: item.name, // 圖片標題
            }
            this.UploadImg = data;
            this.submit();
        },
        submit: function () {
            let settings = {
                async: false,
                crossDomain: true,
                processData: false,
                contentType: false,
                type: 'post',
                url: '/ProductManage/UploadImg',
                mimeType: 'multipart/form-data'
            };
            let url = "";
            let form = new FormData();
            form.append('image', this.UploadImg.file);
            form.append('title', this.UploadImg.title);
            form.append('description', '');
            //form.append('album', file.album); // 有要指定的相簿就加這行
            settings.data = form;
            $.ajax(settings).done(function (res) {
                //console.log(res); // 可以看見上傳成功後回的值
                url = res;
            });
            this.logoImage = url;
            //this.showImage(url);
        },
        showImage: function (url) {
            let father = '#LogoImageArea';
            let u = $('<div></div>').attr('class', 'ImgArea');
            $(father).append(u);
            u.attr('style', 'background-image: url("' + url + '");');

        }
    }
});
var SubmitVue = new Vue({
    el: '#submitVue',
    methods: {
        createActivity: function () {
            let Activity = {
                ActivityID: obj.ActivityID,
                ProductName: Proto.ProName,
                Title: Proto.ProTitle,
                Content: Proto.ProContext,
                Time: Proto.DueDate,
                Picture: ImgVue.logoImage
            }
            $.ajax({
                url: "/ActivityManage/UpDate",
                type: "post",
                data: { jdata: JSON.stringify(Activity) },

                success: function () {
                    window.location.href = "/ActivityManage/Index"
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                }
            });
        }
    }
})