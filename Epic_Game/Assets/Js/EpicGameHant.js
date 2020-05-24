var searchbar = document.querySelector('.navbar .form-control');
var navBar = document.querySelector('.navbar');
var searchnav = document.querySelector('svg');
var onoff = false;
var li = document.querySelector('.div_itemlist li');
console.log(searchbar);
searchnav.addEventListener('click', function () {
    if (onoff == false) {
        searchbar.setAttribute('style', 'display: block');
        navBar.setAttribute('style', 'width: 100%');
        onoff = true;
    }
    else if (onoff == true) {
        searchbar.setAttribute('style', 'display: none');
        navBar.setAttribute('style', 'width: initial');

        onoff = false;
    }
});