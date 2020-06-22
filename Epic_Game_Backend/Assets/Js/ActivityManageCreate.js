//輸入框
var Proto = new Vue({
    el: '#activityitem',   
    data: {
        ProTitle: "",
        ProName: "",
        ProContext: "",
        DueDate: ""
    }
});
//圖片
var ImgVue = new Vue({
    el: '#app',
    data: {
        logoImage: "",
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
                ProductName: Proto.ProName,
                Title: Proto.ProTitle,
                Content: Proto.ProContext,
                Time: Proto.DueDate,
                Picture: ImgVue.logoImage
            }
            $.ajax({
                url: "/ActivityManage/CreateAct",
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