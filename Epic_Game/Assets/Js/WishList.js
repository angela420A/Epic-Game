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
                wishlist_List.appendChild(li);

                let wishitem = document.createElement('div');
                wishitem.className = "wishitem";
                li.appendChild(wishitem);

                let iteminfo = document.createElement('a');
                iteminfo.href = `/Index/Product/${jdata[i]["ProductId"]}`;
                iteminfo.classList.add("col", "itemInfo");
                wishitem.appendChild(iteminfo);

                let ImgArea = document.createElement('div');
                ImgArea.className = "wishItem-ImgArea";
                iteminfo.appendChild(ImgArea);

                let img = document.createElement('img');
                img.src = `${jdata[i]["Img_Url"]}`;
                ImgArea.appendChild(img);

                let infoArea = document.createElement('div');
                infoArea.classList.add("wishItem-infoArea", "col")
                iteminfo.appendChild(infoArea);

                let ProductName_div = document.createElement('div');
                ProductName_div.classList = "infoArea-productName";
                infoArea.appendChild(ProductName_div);

                let productname = document.createElement('p');
                productname.innerHTML = `${jdata[i]["ProductName"]}`;
                ProductName_div.appendChild(productname);

                let price_div = document.createElement('div');
                price_div.className = "infoArea-productPrice";
                infoArea.appendChild(price_div);

                let price = document.createElement('p');
                price.innerHTML = `${jdata[i]["Price"]}`
                price_div.appendChild(price);

                let btn_area = document.createElement('div');
                btn_area.className = "wishItem-btnArea";
                wishitem.appendChild(btn_area);

                let btn = document.createElement('button');
                btn.className = "changeHeart";
                btn.id = `${jdata[i]["ProductId"]}`;
                btn_area.appendChild(btn);

                let icon = document.createElement('i');
                icon.classList.add("fas", "fa-heart");
                btn.appendChild(icon);
            }
            alert("123");
        },
        error: function () { alert("error"); }
    });
})