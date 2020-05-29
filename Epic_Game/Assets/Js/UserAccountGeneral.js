
window.onload = initiate();
let displayName = document.querySelector('#accountDisplayName').value;
let email = document.querySelector('#accountEmail').value;

//add options to birthday select form

function initiate() {
    setBirthdaySelection();
    setEvents();
}

function setEvents() {
    let select_y = document.querySelector('#BD_year');
    select_y.addEventListener('change', setDateSelect);

    let select_m = document.querySelector('#BD_month');
    select_m.addEventListener('change', setDateSelect);

    let editDisplayNameBtn = document.querySelector('#editDisplayNameBtn');
    editDisplayNameBtn.addEventListener('click', enableDisplayNameEdit);
}

function enableDisplayNameEdit() {
    let input = document.querySelector('#accountDisplayName');
    if (input.disabled == true) {
        input.disabled = false;
    } else {
        changeDisplayName();
        input.disabled = true;
    }
}

function changeDisplayName() {
    let newName = document.querySelector('#accountDisplayName').value;
    if (!(newName == displayName)) {
        $.ajax({
            url: "/UserAccount/ChangeDisplayName",
            type: "post",
            data: { jdata: newName },
            success: function () {
                alert('You have changed your display name.');
                displayName = document.querySelector('#accountDisplayName').value;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.status);
                alert(XMLHttpRequest.readyState);
                alert(textStatus);
                document.querySelector('#accountDisplayName').disabled = false;
            }
            
        })
    }
}

function enableEmailEdit() {
    let input = document.querySelector('#accountEmail');
    debugger;
    if (input.disabled == true) {
        input.disabled = false;
    } else {
        changeEmail();
        input.disabled = true;
    }
}

function changeEmail() {
    debugger;
    let newEmail = document.querySelector('#accountEmail').value;
    if (!(newEmail == email)) {
        $.ajax({
            url: "/UserAccount/ChangeEmail",
            type: "post",
            data: { jdata: newEmail },
            success: function () {
                alert('You have changed your e-mail address.');
                email = document.querySelector('#accountEmail').value;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.status);
                alert(XMLHttpRequest.readyState);
                alert(textStatus);
                document.querySelector('#accountEmail').disabled = false;
            }

        })
    }
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