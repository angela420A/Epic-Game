
var a = new Vue({
    el: '#app',
    data: {
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
        },
        UploadList: [],
        ImgArray: []
    },
    methods: {
        changeColor: function () {
            let inputTarget = event.target;
            if (inputTarget.className.includes('primary')) {
                inputTarget.setAttribute('class', 'btn btn-secondary')
            } else {
                inputTarget.setAttribute('class', 'btn btn-primary')
            }
        },
        showFile(e) {
            var t = e.target.files;
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
                debugger;
                this.UploadList.push(data);
            }

            //demo
            this.submit();
        },
        submit: async function () {
            debugger;
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
            debugger;
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
            array.forEach(element => {
                this.ImgArray.push(element);
            })
            debugger;
            this.UploadList = [];

            //demo
            setTimeout(this.showImage(), 5000);
            
        },
        showImage: function () {
            debugger;
            this.ImgArray.forEach(Image => {
                let u = $('<div></div>').attr('class', 'ImgArea');
                $('#storeImg').append(u);
                u.attr('style', 'background-image: url("' + Image + '");');

                //let y = $('<img>').attr('src', Image);
                //$('#storeImg').append(y);

            });
        }
    },
    computed: {
        // showCategories: function () {
        //     let area = document.querySelector('#showCtgy');
        //     let frag = document.createDocumentFragment();
        //     area.innerHTML = "";
        //     this.CategoriesGroup.forEach(element => {
        //         let node = document.createElement('label');
        //         node.setAttribute('class', 'btn btn-success')
        //         node.innerHTML = this.CategoriesText[element];
        //         frag.appendChild(node);
        //     });
        //     area.appendChild(frag);
        // }
    }
})