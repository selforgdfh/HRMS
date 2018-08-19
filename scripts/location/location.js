
$(document).ready(function () {

    LoadLocation();
    $('#btnSave').click(function () {
        Save();
    });

    $('#btnDelete').click(function () {
        Save();
    });

});

function Save() {
    $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "Location/Save", // Controller/View   
                dataType: "json",
                data: {
                    username: $('#txtUserName').val(),
                    password: $('#txtPassword').val()
                }

            }).done(function (data) {
                var myJsonObject = data;
                var msg = "";
                if (myJsonObject == 2)
                    msg = "Invalid User ID";
                else if (myJsonObject == 3)
                    msg = "Invalid Password";
                else if (myJsonObject == 4)
                    msg = "Account Inactive";
                $('#loginfailed').html(msg);
            });

}

function btnDelete() {
    $.ajax(
            {
                type: "POST",
                url: "Location/Delete",
                dataType: "json",
                data: {
                    username: $('#txtUserName').val(),
                    password: $('#txtPassword').val()
                }

            }).done(function (data) {
                var myJsonObject = data;
                var msg = "";
                if (myJsonObject == 2)
                    msg = "Invalid User ID";
                else if (myJsonObject == 3)
                    msg = "Invalid Password";
                else if (myJsonObject == 4)
                    msg = "Account Inactive";
                $('#loginfailed').html(msg);
            });

}
function LoadLocation() {
    $.ajax(
            {
                type: "POST",
                url: "location/GetLocation",
                dataType: "json"

            }).done(function (data) {
                $('#ddtree').html(data);
            }).fail(function (jqXHR, textStatus) {
                alert(textStatus);
            });
}