var upload = new Vue({
    el: '#upload',
    data: {
        showurl: "",
        file: null,
        fs: {
            name: '',
            thumbnail: null,
            size: null
        },
        title: '',
        des: '',
        notnull: false
    },
    methods: {
        showFile(e) {
            this.file = e.target.files[0];
            this.fs.name = this.file.name;
            this.fs.size = Math.floor(this.file.size * 0.001) + 'KB';
            this.fs.thumbnail = window.URL.createObjectURL(this.file);
            this.title = this.fs.name;
        },
        submiturl: function () {
            let settings = {
                async: false,
                crossDomain: true,
                processData: false,
                contentType: false,
                type: 'POST',
                url: '/ProductManage/UploadImg',
                mimeType: 'multipart/form-data'
            };

            let form = new FormData();
            form.append('image', this.file);
            form.append('title', this.title);
            form.append('description', this.des);

            settings.data = form;
            let t;
            $.ajax(settings).done(function (res) {
                t = res;
            });
            this.showurl = t;
        }
    }
});