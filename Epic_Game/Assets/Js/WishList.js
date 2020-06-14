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

let wishCount_text = document.querySelector(".wishCount_text");
wishCount_text.innerText = `${document.querySelectorAll(".changeHeart").length} items`;

let hot_sale = document.querySelector("#hot_sale");
hot_sale.addEventListener('click', () => {
    $.ajax({
        url: '/WishList/ShowOrder',
        data: { Key: "ProductCount", boolean: true },
        type: 'post',
        success: function (jdata) {
            $(".wishlist-List").empty();
            let wishlist_List = document.querySelector(".wishlist-List");

            for (let i = 0; i < jdata.length; i++) {

                let li = document.createElement('li');
                li.className = "wishList-ListItem";

                let wishitem = document.createElement('div');
                wishitem.className = "wishItem";
                li.appendChild(wishitem);

                let iteminfo = document.createElement('a');
                iteminfo.href = `/Index/Product/${jdata[i]["ProductID"]}`;
                iteminfo.classList.add("col", "itemInfo");

                let ImgArea = document.createElement('div');
                ImgArea.className = "wishItem-ImgArea";

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;

                let infoArea = document.createElement('div');
                infoArea.classList.add("wishItem-infoArea", "col")

                let ProductName_div = document.createElement('div');
                ProductName_div.classList = "infoArea-productName";

                let productname = document.createElement('p');
                productname.innerHTML = `${jdata[i]["ProductName"]}`;

                let price_div = document.createElement('div');
                price_div.className = "infoArea-productPrice";

                let price = document.createElement('p');
                price.innerHTML = `${jdata[i]["Price"]}`

                let btn_area = document.createElement('div');
                btn_area.className = "wishItem-btnArea";

                let btn = document.createElement('button');
                btn.className = "changeHeart";
                btn.id = `${jdata[i]["ProductID"]}`;

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-heart");

                ImgArea.appendChild(img);
                ProductName_div.appendChild(productname);
                price_div.appendChild(price);
                infoArea.appendChild(ProductName_div);
                infoArea.appendChild(price_div);
                iteminfo.appendChild(ImgArea);
                iteminfo.appendChild(infoArea);
                btn.appendChild(icon);
                btn_area.appendChild(btn);
                wishitem.appendChild(iteminfo);
                wishitem.appendChild(btn_area);
                wishlist_List.appendChild(li);

                AddEven();
            }
        },
        error: function () { alert("error"); }
    });
})

let recently = document.querySelector("#recently");
recently.addEventListener('click', () => {
    $.ajax({
        url: '/WishList/ShowOrder',
        data: { Key: "Date", boolean: true },
        type: 'post',
        success: function (jdata) {
            $(".wishlist-List").empty();
            let wishlist_List = document.querySelector(".wishlist-List");

            for (let i = 0; i < jdata.length; i++) {

                let li = document.createElement('li');
                li.className = "wishList-ListItem";

                let wishitem = document.createElement('div');
                wishitem.className = "wishItem";
                li.appendChild(wishitem);

                let iteminfo = document.createElement('a');
                iteminfo.href = `/Index/Product/${jdata[i]["ProductID"]}`;
                iteminfo.classList.add("col", "itemInfo");

                let ImgArea = document.createElement('div');
                ImgArea.className = "wishItem-ImgArea";

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;

                let infoArea = document.createElement('div');
                infoArea.classList.add("wishItem-infoArea", "col")

                let ProductName_div = document.createElement('div');
                ProductName_div.classList = "infoArea-productName";

                let productname = document.createElement('p');
                productname.innerHTML = `${jdata[i]["ProductName"]}`;

                let price_div = document.createElement('div');
                price_div.className = "infoArea-productPrice";

                let price = document.createElement('p');
                price.innerHTML = `${jdata[i]["Price"]}`

                let btn_area = document.createElement('div');
                btn_area.className = "wishItem-btnArea";

                let btn = document.createElement('button');
                btn.className = "changeHeart";
                btn.id = `${jdata[i]["ProductID"]}`;

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-heart");

                ImgArea.appendChild(img);
                ProductName_div.appendChild(productname);
                price_div.appendChild(price);
                infoArea.appendChild(ProductName_div);
                infoArea.appendChild(price_div);
                iteminfo.appendChild(ImgArea);
                iteminfo.appendChild(infoArea);
                btn.appendChild(icon);
                btn_area.appendChild(btn);
                wishitem.appendChild(iteminfo);
                wishitem.appendChild(btn_area);
                wishlist_List.appendChild(li);

                AddEven();
            }
        },
        error: function () { alert("error"); }
    });
})

let alphabet = document.querySelector("#alphabet");
alphabet.addEventListener('click', () => {
    $.ajax({
        url: '/WishList/ShowOrder',
        data: { Key: "ProductName", boolean: true },
        type: 'post',
        success: function (jdata) {
            $(".wishlist-List").empty();
            let wishlist_List = document.querySelector(".wishlist-List");

            for (let i = 0; i < jdata.length; i++) {

                let li = document.createElement('li');
                li.className = "wishList-ListItem";

                let wishitem = document.createElement('div');
                wishitem.className = "wishItem";
                li.appendChild(wishitem);

                let iteminfo = document.createElement('a');
                iteminfo.href = `/Index/Product/${jdata[i]["ProductID"]}`;
                iteminfo.classList.add("col", "itemInfo");

                let ImgArea = document.createElement('div');
                ImgArea.className = "wishItem-ImgArea";

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;

                let infoArea = document.createElement('div');
                infoArea.classList.add("wishItem-infoArea", "col")

                let ProductName_div = document.createElement('div');
                ProductName_div.classList = "infoArea-productName";

                let productname = document.createElement('p');
                productname.innerHTML = `${jdata[i]["ProductName"]}`;

                let price_div = document.createElement('div');
                price_div.className = "infoArea-productPrice";

                let price = document.createElement('p');
                price.innerHTML = `${jdata[i]["Price"]}`

                let btn_area = document.createElement('div');
                btn_area.className = "wishItem-btnArea";

                let btn = document.createElement('button');
                btn.className = "changeHeart";
                btn.id = `${jdata[i]["ProductID"]}`;

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-heart");

                ImgArea.appendChild(img);
                ProductName_div.appendChild(productname);
                price_div.appendChild(price);
                infoArea.appendChild(ProductName_div);
                infoArea.appendChild(price_div);
                iteminfo.appendChild(ImgArea);
                iteminfo.appendChild(infoArea);
                btn.appendChild(icon);
                btn_area.appendChild(btn);
                wishitem.appendChild(iteminfo);
                wishitem.appendChild(btn_area);
                wishlist_List.appendChild(li);

                AddEven();
            }
        },
        error: function () { alert("error"); }
    });
})

let price_true = document.querySelector("#price_true");
price_true.addEventListener('click', () => {
    $.ajax({
        url: '/WishList/ShowOrder',
        data: { Key: "Price", boolean: true },
        type: 'post',
        success: function (jdata) {
            $(".wishlist-List").empty();
            let wishlist_List = document.querySelector(".wishlist-List");

            for (let i = 0; i < jdata.length; i++) {

                let li = document.createElement('li');
                li.className = "wishList-ListItem";

                let wishitem = document.createElement('div');
                wishitem.className = "wishItem";
                li.appendChild(wishitem);

                let iteminfo = document.createElement('a');
                iteminfo.href = `/Index/Product/${jdata[i]["ProductID"]}`;
                iteminfo.classList.add("col", "itemInfo");

                let ImgArea = document.createElement('div');
                ImgArea.className = "wishItem-ImgArea";

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;

                let infoArea = document.createElement('div');
                infoArea.classList.add("wishItem-infoArea", "col")

                let ProductName_div = document.createElement('div');
                ProductName_div.classList = "infoArea-productName";

                let productname = document.createElement('p');
                productname.innerHTML = `${jdata[i]["ProductName"]}`;

                let price_div = document.createElement('div');
                price_div.className = "infoArea-productPrice";

                let price = document.createElement('p');
                price.innerHTML = `${jdata[i]["Price"]}`

                let btn_area = document.createElement('div');
                btn_area.className = "wishItem-btnArea";

                let btn = document.createElement('button');
                btn.className = "changeHeart";
                btn.id = `${jdata[i]["ProductID"]}`;

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-heart");

                ImgArea.appendChild(img);
                ProductName_div.appendChild(productname);
                price_div.appendChild(price);
                infoArea.appendChild(ProductName_div);
                infoArea.appendChild(price_div);
                iteminfo.appendChild(ImgArea);
                iteminfo.appendChild(infoArea);
                btn.appendChild(icon);
                btn_area.appendChild(btn);
                wishitem.appendChild(iteminfo);
                wishitem.appendChild(btn_area);
                wishlist_List.appendChild(li);

                AddEven();
            }
        },
        error: function () { alert("error"); }
    });
})

let price_false = document.querySelector("#price_false");
price_false.addEventListener('click', () => {
    $.ajax({
        url: '/WishList/ShowOrder',
        data: { Key: "Price", boolean: false },
        type: 'post',
        success: function (jdata) {
            $(".wishlist-List").empty();
            let wishlist_List = document.querySelector(".wishlist-List");

            for (let i = 0; i < jdata.length; i++) {

                let li = document.createElement('li');
                li.className = "wishList-ListItem";

                let wishitem = document.createElement('div');
                wishitem.className = "wishItem";
                li.appendChild(wishitem);

                let iteminfo = document.createElement('a');
                iteminfo.href = `/Index/Product/${jdata[i]["ProductID"]}`;
                iteminfo.classList.add("col", "itemInfo");

                let ImgArea = document.createElement('div');
                ImgArea.className = "wishItem-ImgArea";

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;

                let infoArea = document.createElement('div');
                infoArea.classList.add("wishItem-infoArea", "col")

                let ProductName_div = document.createElement('div');
                ProductName_div.classList = "infoArea-productName";

                let productname = document.createElement('p');
                productname.innerHTML = `${jdata[i]["ProductName"]}`;

                let price_div = document.createElement('div');
                price_div.className = "infoArea-productPrice";

                let price = document.createElement('p');
                price.innerHTML = `${jdata[i]["Price"]}`

                let btn_area = document.createElement('div');
                btn_area.className = "wishItem-btnArea";

                let btn = document.createElement('button');
                btn.className = "changeHeart";
                btn.id = `${jdata[i]["ProductID"]}`;

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-heart");

                ImgArea.appendChild(img);
                ProductName_div.appendChild(productname);
                price_div.appendChild(price);
                infoArea.appendChild(ProductName_div);
                infoArea.appendChild(price_div);
                iteminfo.appendChild(ImgArea);
                iteminfo.appendChild(infoArea);
                btn.appendChild(icon);
                btn_area.appendChild(btn);
                wishitem.appendChild(iteminfo);
                wishitem.appendChild(btn_area);
                wishlist_List.appendChild(li);

                AddEven();
            }
        },
        error: function () { alert("error"); }
    });
})
