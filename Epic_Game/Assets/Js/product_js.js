var searchbar = document.querySelector('.navbar .form-control');
var searchnav = document.querySelector('svg');
var onoff = false;
var li = document.querySelector('.div_itemlist li');
console.log(searchbar);
searchnav.addEventListener('click', function () {
    if (onoff == false) {
        searchbar.setAttribute('style', 'display: block');
        onoff = true;
    }
    else if (onoff == true) {
        searchbar.setAttribute('style', 'display: none');
        onoff = false;
    }
});