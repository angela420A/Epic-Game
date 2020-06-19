window.onload = AddEven();

function AddEven() {
    document.querySelectorAll(".changeHeart").forEach((item) => {
        item.addEventListener('click', ChangeWish);
    });
}

function ChangeWish() {
    let redirectTo = "Product";
    let productID = this.id;
    let span = this.getElementsByClassName('fas')[0];
    let className = span.getAttribute('class');
    let data = {
        ProductID: productID,
        redirectTo: redirectTo
    }
    $.ajax({
        url: '/WishList/ChangeWish',
        type: 'post',
        data: { jdata: JSON.stringify(data) },
        success: function () {
            if (className.includes('fa-undo')) {
                span.setAttribute('class', 'fas fa-heart');
            }
            else {
                span.setAttribute('class', 'fas fa-undo');
            }
        },
        error: function () {
            alert("remove failed.");
        }
    });
}

document.querySelector(".wishCount_text").innerText = `${document.querySelectorAll(".changeHeart").length} items`;

document.querySelector("#hot_sale").addEventListener('click', () => {
    Create_li("ProductCount", true);
});

document.querySelector("#recently").addEventListener('click', () => {
    Create_li("Date", true);
});

document.querySelector("#alphabet").addEventListener('click', () => {
    Create_li("ProductName", true);
});

document.querySelector("#price_true").addEventListener('click', () => {
    Create_li("Price", true);
});

document.querySelector("#price_false").addEventListener('click', () => {
    Create_li("Price", false);
});

function Create_li(_Key,_bool) {
    $.ajax({
        url: '/WishList/ShowOrder',
        data: { Key: `${_Key}`, boolean: _bool },
        type: 'post',
        success: function (jdata) {
            for (let i = 0; i < jdata.length; i++) {
                $(`.wishlist-List`).empty();

                $('.wishlist-List').append($('<li>', { class: 'wishList-ListItem' }));
                $(`.wishList-ListItem:eq(${i})`).html($('<div>', { class: 'wishItem' }));
                $(`.wishItem:eq(${i})`).html(`<a href="/Product/${jdata[i]["ProductID"]}" class="col itemInfo"></a><div class="wishItem-btnArea"></div>`);
                $(`.itemInfo:eq(${i})`).html('<div class="wishItem-ImgArea"></div><div class="wishItem-infoArea col"></div>');
                $(`.wishItem-ImgArea:eq(${i})`).html($('<img>', { src: `${jdata[i]["Img_Url"]}` }));
                $(`.wishItem-infoArea:eq(${i})`).html($('<div class="infoArea-productName"></div><div class="infoArea-productPrice"></div>'));
                $(`.infoArea-productName:eq(${i})`).html($('<p>').text(`${jdata[i]["ProductName"]}`));
                $(`.infoArea-productPrice:eq(${i})`).html($('<p>').text(`$NTD : ${jdata[i]["Price"]}`));
                $(`.wishItem-btnArea:eq(${i})`).html($('<button>', { class: 'changeHeart', id: `${jdata[i]["ProductID"]}` }));
                $(`.changeHeart:eq(${i})`).html($('<i>', { class: 'fas fa-heart' }));

                AddEven();
            }
        },
        error: function () { alert("error"); }
    });
}