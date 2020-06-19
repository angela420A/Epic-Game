let dis_img = document.querySelector(".dis_img");
let dis_list = document.querySelector(".dis_list");
let dis_style = document.querySelector("#dis_style");


dis_img.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_img.css";
    document.querySelectorAll(".game_div").forEach((item) => {
        item.classList.add("col-xl-4", "col-md-6");
    });
})

dis_list.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_list.css";
    document.querySelectorAll(".game_div").forEach((item) => {
        item.className = "game_div";
        item.classList.add("col-12");
    });
})

document.querySelector(".link_icon").addEventListener('click', () => {

})


let recent = document.querySelector(".recent");
let alphabetical = document.querySelector(".alphabetical");

recent.addEventListener('click', () => {
    Create_products("Date");
})

alphabetical.addEventListener('click', () => {
    Create_products("ProductName");
})

function Create_products(_Key) {
    dis_style.href = "/Assets/css/dis_img.css";
    $.ajax({
        url: '/Library/ShowOrder',
        data: { Key: `${_Key}` },
        type: 'post',
        success: function (jdata) {
            $(".game_products").empty();

            for (let i = 0; i <= jdata.length; i++) {
                $('.game_products').append($('<div>', { class: 'col-12 col-lg-6 col-xl-4 game_div', id: `${jdata[i]["ProductId"]}` }));
                $(`.game_div:eq(${i})`).html($('<div>', { class: 'game_div_insidebox' }));
                $(`.game_div_insidebox:eq(${i})`).html($(
                    `<div class="product_pic"></div><h3>${jdata[i]["ProductName"]}</h3><a class="link_icon" href ="/Product/${jdata[i]["ProductId"]}"><i class="fas fa-link"></i></a>`
                ));
                $(`.product_pic:eq(${i})`).html($(`<img class="main_pic" src="${jdata[i]["Img_Url"]}"/><img class="logo_pic" src="${jdata[i]["Img_Url_list"]}"/>`))
            }
        },
        error: function () { alert("error"); }
    });
}