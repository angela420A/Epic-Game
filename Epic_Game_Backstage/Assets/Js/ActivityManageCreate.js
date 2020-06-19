//輸入框
var Proto = new Vue({
    el: 'activityitem',
    data: {
        ProTitle: "",
        ProName: "",
        ProContext: "",
        //DueDate: ""
    },

    methods: {
        createActivity: function (p) {
            let object = {
                ProductName: this.ProName,
                Title: this.ProTitle,
                Content: this.ProContext,
                //Time: this.DueDate
            }
            $.ajax({
                url: "/ActivityManage/Create",
                type: "post",
                data: { jada: JSON.stringify(ActivityVM) },
                success: function () {
                    window.location.href = "/ActivityManage/Index"
                },
                error: function () {
                    alert("Error");
                }
            })
        },
    }

});
//圖片
var ImgVue = new Vue({
    el: '#app',
    data: {
        logoImage: "",
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
                url: '/ActivityManage/UploadImg',
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
                    case "LogoImage":
                        this.logoImage = element;
                        break;
                    //case "SwiperImage":
                    //    this.swiperList.push(element);
                    //    break;
                    //case "screenShot":
                    //    PIntroVue.swiperList.push(element);
                    //    break;
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
        }
    }
});