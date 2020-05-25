
window.onload = setBirthdaySelection();





//add options to birthday select form
let bd = "@Model.Birthday".split(".");
let bd_year = bd[0];
let bd_month = bd[1];
let bd_date = bd[2];

function setBirthdaySelection() {
    let select_y = document.querySelector('#BD_year');
    let select_m = document.querySelector('#BD_month');
    let select_d = document.querySelector('#BD_date');
    let year = new Date().getFullYear();

    let yearFragment = document.createDocumentFragment();
    for (let i = year; i > 1920; i--) {
        let option = document.createElement('option');
        option.value = i;
        option.innerHTML = i.toString();
        yearFragment.appendChild(option);
    }
    select_y.appendChild(yearFragment);


    let monthFragment = document.createDocumentFragment();
    for (let i = 1; i < 13; i++) {
        let option = document.createElement('option');
        option.value = i;
        option.innerHTML = i.toString();
        monthFragment.appendChild(option);
    }
    select_m.appendChild(monthFragment);

}

        //$('#saveBtn').click(function () {
        //    var obj = {
        //        AddressLine: $('#userAddressI').val(),
        //        City: $('#userCity').val(),
        //        Postalcode: $('#userPostalCode').val(),
        //        Country: $('#userCountry').val()
        //    };



        //    $.ajax({
        //        url: "/UserAccount/SaveChanges",
        //        type: "post",
        //        data: {
        //            jdata = JSON.stringify(obj)
        //        },
        //        success: function () {
        //            alert('Your Infomation has been changed!');
        //        }
        //    });
        //);