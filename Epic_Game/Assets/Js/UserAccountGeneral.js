
window.onload = initiate();
let displayName = document.querySelector('#accountDisplayName').value;
let email = document.querySelector('#accountEmail').value;
//add options to birthday select form

function initiate() {
    setBirthdaySelection();
    setEvents();
    //***I try to use razor form but it was a disaster...***//
    //let SquareBtnArea_EditDisplayName = document.querySelector('#SquareBtnArea_EditDisplayName');
    //let temp = document.querySelector('#startEditDisplayName');
    //let startEditDisplayName = temp.cloneNode(true);
    //debugger;
    //SquareBtnArea_EditDisplayName.innerHTML = startEditDisplayName.innerHTML;
}

function setEvents() {
    let select_y = document.querySelector('#BD_year');
    select_y.addEventListener('change', setDateSelect);

    let select_m = document.querySelector('#BD_month');
    select_m.addEventListener('change', setDateSelect);

    let editDisplayNameBtn = document.querySelector('#editDisplayNameBtn');
    editDisplayNameBtn.addEventListener('click', enableDisplayNameEdit);

    let editEmailBtn = document.querySelector('#editEmailBtn');
    editEmailBtn.addEventListener('click', enableEmailEdit);

    let saveBtn_Personal = document.querySelector('#saveBtn_Personal');
    saveBtn_Personal.addEventListener('click', changePersonalInfo);

    $('#saveBtn_Address').click(changeAddress);

    $('#desgardBtn_Address').click(DesgardChangeAddress);

    $('#desgardBtn_Personal').click(DesgardChangePersonalInfo);


}

function enableDisplayNameEdit() {
    let input = document.querySelector('#accountDisplayName');
    if (input.disabled == true) {
        input.disabled = false;
    } else {
        input.disabled = true;
        changeDisplayName();
    }
}

function changeDisplayName() {
    let newName = document.querySelector('#accountDisplayName').value;
    if (!(newName == displayName)) {
        $.ajax({
            url: "/UserAccount/ChangeDisplayName",
            type: "post",
            data: AddAntiForgeryToken({ jdata: newName }),
            success: function () {
                alert('You have changed your display name.');
                displayName = document.querySelector('#accountDisplayName').value;
            },
            error: function () {
                alert("You need to enter valid nickname.");
                $('#accountDisplayName').val(displayName);
                document.querySelector('#accountDisplayName').disabled = false;
            }
        })
    }
}

function enableEmailEdit() {
    let input = document.querySelector('#accountEmail');
    if (input.disabled == true) {
        input.disabled = false;
    } else {
        input.disabled = true;
        changeEmail();
    }
}

function changeEmail() {
    let newEmail = document.querySelector('#accountEmail').value;
    if (!(newEmail == email)) {
        $.ajax({
            url: "/UserAccount/ChangeEmail",
            type: "post",
            data: AddAntiForgeryToken({ jdata: newEmail }),
            success: function () {
                alert('You have changed your e-mail address.');
                email = document.querySelector('#accountEmail').value;
            },
            error: function () {
                alert("You need to enter valid e-mail address.");
                $('#accountEmail').val(email);
                document.querySelector('#accountEmail').disabled = false;
            }
        })
    }
}

function changePersonalInfo() {
    let obj = {
        FirstName: document.querySelector('#userFirstName').value,
        LastName : document.querySelector('#userLastName').value,
        Birthday :
        document.querySelector('#BD_year').selectedOptions[0].value + "."
        + document.querySelector('#BD_month').selectedOptions[0].value + "."
        + document.querySelector('#BD_date').selectedOptions[0].value
    }

    let jdata = JSON.stringify(obj);

    $.ajax({
        url: "/UserAccount/ChangePersonalInfo",
        type: "post",
        data: AddAntiForgeryToken({ jdata }),
        success: function () {
            alert('You have changed your personal Information.');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.readyState);
            alert(textStatus);
        }
    })
}

function changeAddress() {
    let obj = {
        AddressLine: $("#userAddressI").val(),
        City: $("#userCity").val(),
        Postalcode: $("#userPostalCode").val(),
        Country: $("#userCountry").val()
    }

    let jdata = JSON.stringify(obj);

    $.ajax({
        url: "/UserAccount/ChangeAddress",
        type: "post",
        data: AddAntiForgeryToken({ jdata }),
        success: function () {
            alert('You have changed your address Information.');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.readyState);
            alert(textStatus);
        }
    })
}

function DesgardChangeAddress() {
    $.ajax({
        url: "/UserAccount/GetUserInfoJSON",
        type: "get",
        dataType: 'json',
        success: function (jdata) {
            $('#userAddressI').val(jdata["AddressLine"]);
            $('#userCity').val(jdata["City"]);
            $('#userPostalCode').val(jdata["Postalcode"]);
            $('#userCountry').val(jdata["Country"]);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.readyState);
            alert(textStatus);
        }
    })
}

function DesgardChangePersonalInfo() {
    $.ajax({
        url: "/UserAccount/GetUserInfoJSON",
        type: "get",
        dataType: 'json',
        success: function (jdata) {
            $('#userFirstName').val(jdata["FirstName"]);
            $('#userLastName').val(jdata["LastName"]);
            let YMD = jdata["Birthday"].split(".");
            setBirthday(YMD);
            debugger;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.readyState);
            alert(textStatus);
        }
    })
}

function setBirthday(str) {
    let yy = parseInt(str[0]);
    let y = new Date().getFullYear();

    let BD_Select_y = document.querySelector('#BD_year');
    BD_Select_y.selectedIndex = y - yy;

    let BD_Select_m = document.querySelector('#BD_month');
    BD_Select_m.selectedIndex = parseInt(str[1]) - 1;

    setDateSelect();

    let BD_Select_d = document.querySelector('#BD_date');
    BD_Select_d.selectedIndex = parseInt(str[2]) - 1;
}

function setBirthdaySelection() {
    let select_y = document.querySelector('#BD_year');
    let select_m = document.querySelector('#BD_month');
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

//reset opstions in date select
function setDateSelect() {
    let year = parseInt(document.querySelector('#BD_year').selectedOptions[0].innerHTML);
    let month = parseInt(document.querySelector('#BD_month').selectedOptions[0].innerHTML);
    let days = new Date(year, month, 0).getDate();
    let select_d = document.querySelector('#BD_date');
    let dateFragment = document.createDocumentFragment();
    for (let i = 1; i <= days; i++) {
        let option = document.createElement('option');
        option.value = i;
        option.innerHTML = i.toString();
        dateFragment.appendChild(option);
    }
    select_d.appendChild(dateFragment);
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