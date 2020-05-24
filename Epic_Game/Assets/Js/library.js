let dis_img = document.querySelector(".dis_img");
let dis_list = document.querySelector(".dis_list");
let game_div = document.querySelector("#game_div");
let dis_style = document.querySelector("#dis_style");
let download = document.querySelector(".download_icon");
download.addEventListener('click', () => {
    $('#exampleModal').modal('toggle');
})
dis_img.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_img.css";
    game_div.classList.add("col-xl-4");
    game_div.classList.add("col-md-6");
})
dis_list.addEventListener('click', () => {
    dis_style.href = "/Assets/css/dis_list.css";
    game_div.className = "col-12";
})
//123