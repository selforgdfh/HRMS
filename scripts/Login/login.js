
$(document).ready(function () {
    $("#BtnSubmit").click(function () {
        $.ajax(
        {
            type: "POST", //HTTP POST Method  
            url: "Login/Login", // Controller/View   
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

    });
});