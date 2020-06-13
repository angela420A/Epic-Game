let dis_img = document.querySelector(".dis_img");
let dis_list = document.querySelector(".dis_list");
let game_div = document.querySelectorAll(".game_div");
let dis_style = document.querySelector("#dis_style");
let link = document.querySelector(".link_icon");

dis_img.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_img.css";
    game_div.forEach((item) => {
        item.classList.add("col-xl-4");
        item.classList.add("col-md-6");
    });
})

dis_list.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_list.css";
    game_div.forEach((item) => {
        item.className = "col-12";
        item.classList.add("game_div");
    });
})

link.addEventListener('click', () => {

})

let recent = document.querySelector(".recent");
let alphabetical = document.querySelector(".alphabetical");

recent.addEventListener('click', () => {
    $.ajax({
        url: '/Library/ShowOrder',
        data: { Key: "Date" },
        type: 'post',
        success: function (jdata) {
            $(".game_products").empty();
            let row = document.querySelector(".game_products");
            for (let i = 0; i < jdata.length; i++) {
                let col = document.createElement('div');
                col.classList.add('col-12', 'col-lg-6', 'col-xl-4', 'game_div');
                col.id = `${jdata[i]["ProductId"]}`;

                let insidebox = document.createElement("div");
                insidebox.className = "game_div_insidebox";

                let pic_box = document.createElement('div');
                pic_box.className = "product_pic";

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;
                img.alt = `game_picture`;

                let title = document.createElement('h3');
                title.innerHTML = `${jdata[i]["ProductName"]}`;

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-link", "link_icon");

                pic_box.appendChild(img);
                insidebox.appendChild(pic_box);
                insidebox.appendChild(title);
                insidebox.appendChild(icon);
                col.appendChild(insidebox);
                row.appendChild(col);
            }
        },
        error: function () { alert("error"); }
    });
})

alphabetical.addEventListener('click', () => {
    $.ajax({
        url: '/Library/ShowOrder',
        data: { Key: "ProductName" },
        type: 'post',
        success: function (jdata) {
            $(".game_products").empty();
            let row = document.querySelector(".game_products");
            for (let i = 0; i < jdata.length; i++) {
                let col = document.createElement('div');
                col.classList.add('col-12', 'col-lg-6', 'col-xl-4', 'game_div');
                col.id = `${jdata[i]["ProductId"]}`;

                let insidebox = document.createElement("div");
                insidebox.className = "game_div_insidebox";

                let pic_box = document.createElement('div');
                pic_box.className = "product_pic";

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;
                img.alt = `game_picture`;

                let title = document.createElement('h3');
                title.innerHTML = `${jdata[i]["ProductName"]}`;

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-link", "link_icon");

                pic_box.appendChild(img);
                insidebox.appendChild(pic_box);
                insidebox.appendChild(title);
                insidebox.appendChild(icon);
                col.appendChild(insidebox);
                row.appendChild(col);
            }
        },
        error: function () { alert("error"); }
    });
})
