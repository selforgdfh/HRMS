
$(document).ready(function () {
    $('#btnSave').click(function () {
        Save();
    })
    $('#btnClear').click(function () {
        Clear();
    })

});

function delemp(empid) {
    $('#' + '<%= t1.ClientID %>').val(empid);
    var btnid = '<%= Button2.ClientID %>';
    if (confirm("Are you sure want to delete this ?")) {
        {

            document.getElementById(btnid).click();
        }
    }
    return false;
}

function Save() {

    var json = JSON.stringify({
        EmpID: $('#txtEmpID').val(),
        Org: $('#txtEMpOrg').val(),
        firstName: $('#txtFirstName').val(),
        lastName: $('#txtLastName').val(),
        department: $('#ddDept').val(),
        location: $('#ddLoc').val(),
        Designation: $('#txtDesignation').val(),
        ReportingTo: "",
        employeeType: $('#ddEmpType').val(),
        Religion: $('#txtReligion').val(),
        visaStatus: $('#txtVisaStatus').val(),
        empStatus: $('#ddStatus').val(),
        Nationality: $('#ddNationality').val(),
        DOB: $('#txtDob').val(),
        gender: $('#ddGender').val(),
        martialStatus: $('#ddMartialStatus').val(),
        accomodation: $('#txtAccomodation').val(),
        passport: $('#txtPassport').val(),

        emirateID: $('#txtEmiratedID').val(),
        bankName: $('#ddBankName').val(),
        bankAccount: $('#txtBankAccount').val(),
        camp: $('#ddCamp').val(),
        empImage: "",
        joining: $('#txtJoiningDate').val(),
        outsource: $('#txtOutsourceEmp').val(),
        remarks: $('#txtRemarks').val()
    });
    $.ajax(
        {
            type: "POST", //HTTP POST Method  
            url: "Employee/Save", // Controller/View   
            dataType: "json",
            data: json, contentType: 'application/json; charset=utf-8'


        }).done(function (data) {
            alert('Saved Successfully');
        });
}

function Clear() {
    $('input').val('');
    $('textarea').val('');
}


function rowClick(id, rowData) {
    loadSpecificRecord(id);
}
function loadSpecificRecord(id) {

    var json = JSON.stringify({ employeeId: id });

    $.ajax({
        url: 'Employee/GetEmployeeRecord',
        type: 'POST',
        dataType: 'json',
        data: json,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var myJsonObject = data;
            $('#txtEmpID').val(myJsonObject[0].employeeId);
            $('#txtEMpOrg').val(myJsonObject[0].empi_ID_Org);
            $('#txtFirstName').val(myJsonObject[0].firstName);
            $('#txtLastName').val(myJsonObject[0].lastName);
            $('#ddDept').val(myJsonObject[0].department);
            $('#ddLoc').val(myJsonObject[0].location);
            $('#txtDesignation').val(myJsonObject[0].Designation);

            $('#ddEmpType').val(myJsonObject[0].emptype);
            $('#txtReligion').val(myJsonObject[0].religion);
            $('#txtVisaStatus').val(myJsonObject[0].visatype);
            $('#ddStatus').val(myJsonObject[0].empstatus);
            $('#ddNationality').val(myJsonObject[0].nationality);
            $('#txtDob').val(myJsonObject[0].DOB);
            $('#ddGender').val(myJsonObject[0].gender);
            $('#ddMartialStatus').val(myJsonObject[0].martialStatus);
            $('#txtAccomodation').val(myJsonObject[0].accomodation);
            $('#txtPassport').val(myJsonObject[0].passport);

            $('#txtEmiratedID').val(myJsonObject[0].emirateID);
            $('#ddBankName').val(myJsonObject[0].bankName);
            $('#txtBankAccount').val(myJsonObject[0].bankAccount);
            $('#ddCamp').val(myJsonObject[0].camp);

            $('#txtJoiningDate').val(myJsonObject[0].joining);
            $('#txtOutsourceEmp').val(myJsonObject[0].outsource);
            $('#txtRemarks').val(myJsonObject[0].remarks);
        }
    }).fail(function (jqXHR, textStatus) {
        alert(textStatus);
    });

}


$(function () {
    debugger;
    $("#Demogrid").jqGrid
    ({
        url: "/Employee/GetEmployee",
        datatype: 'json',
        mtype: 'Get',
        //table header name
        colNames: ['EmployeeID', 'Employee Name', 'Department', 'Location', 'Camp', 'Creation Date', 'Status'],
        //colModel takes the data from controller and binds to grid
        colModel: [
        {
            name: 'employeeId',editable: true,key: true,hidden: true,search: false
        },

        {
            name: "firstName", editable: true, editrules: { required: true }, search: true
        },
        {
            name: "Departmentname", editable: true, editrules: { required: true }, search: false
        },
        {
            name: "LocationName", editable: true, editrules: { required: true }, search: false
        },
        {
            name: "CampName", editable: true, editrules: { required: true, number: true }, search: false
        },
        {
            name: "createdon", editable: true, editrules: { required: true }, search: false
        },
        {
            name: "StatusName", editable: true, editrules: { required: true }, search: false
        }
        ],
        height: '100%',
        viewrecords: true,
        caption: 'JQgrid DEMO',
        emptyrecords: 'No records',
        rowNum: 10,

        pager: jQuery('#pager'),
        rowList: [10, 20, 30, 40],

        jsonReader:
        {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        }, onSelectRow: function (id) {
            var rowData = $(this).getRowData(id);
            rowClick(id, rowData);
            //alert(rowData);
            // if(id!==lastSel){
           // $(this).find('.ui-state-highlight').css({ background: '#80BFFF' });
            //lastSel = id;
            //}
        },
        autowidth: true
    }).navGrid('#pager',
    {
        edit: true,
        add: true,
        del: true,
        search: true,
        refresh: true,
        closeAfterSearch: true
    },
    {
        // edit option
        zIndex: 100,
        url: '/Employee/GetEmployee',
        closeOnEscape: true,
        closeAfterEdit: true,
        recreateForm: true,
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    },
    {
        // add option
        zIndex: 100,
        url: "/Employee/GetEmployee",
        closeOnEscape: true,
        closeAfterAdd: true,
        afterComplete: function (response) {
            if (response.responseJSON) {
                if (response.responseJSON == "Saved Successfully") {
                    alert("Saved Successfully");
                }
                else {
                    var message = "";
                    for (var i = 0; i < response.responseJSON.length; i++) {
                        message += response.responseJSON[i];
                        message += "\n";
                    }
                }

            }
        }
    },
    {
        // delete option
        zIndex: 100,
        url: "/Employee/GetEmployee",
        closeOnEscape: true,
        closeAfterDelete: true,
        recreateForm: true,
        msg: "Are you sure you want to delete this Customer?",
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    }

    );
});