let dis_img = document.querySelector(".dis_img");
let dis_list = document.querySelector(".dis_list");
let game_div = document.querySelectorAll("#game_div");
let dis_style = document.querySelector("#dis_style");
let link = document.querySelector(".link_icon");

dis_img.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_img.css";
    game_div.forEach((item) => {
        item.classList.add("col-xl-4");
        item.classList.add("col-md-6")
    });
})

dis_list.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_list.css";
    game_div.forEach((item) => {
        item.className = "col-12";
    });
})

let recent = document.querySelector(".recent");
let alphabetical = document.querySelector(".alphabetical");

link.addEventListener('click', () => {

})

alphabetical.addEventListener('click', () => {
    $.ajax({
        url: '/Library/OrderLibraryItem',
        data: { Key: "ProductName" },
        type: 'get',
        success: function () { },
        error: function () { alert("error"); }
    });
})
