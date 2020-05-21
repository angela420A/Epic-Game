let dis_img = document.querySelector(".dis_img");
let dis_list = document.querySelector(".dis_list");
let game_div = document.querySelector(".game_div");
let dis_style = document.querySelector("#dis_style");
game_div.addEventListener('click', () => {
    $('#exampleModal').modal('toggle');
})
dis_img.addEventListener('click', () => {
    dis_style.href = "~/Assets/css/dis_img.css";
    game_div.classList.remove("col-md-3");
})
dis_list.addEventListener('click', () => {
    dis_style.href = "~/Assets/css/dis_list.css";
    game_div.classList.add("col-md-3");
})