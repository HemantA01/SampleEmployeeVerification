$(document).ready(function () {
    $('#spnResult').text('');
});
$('#btnSubmit').click(function () {
    var model = new FormData();
    model.append('employeeId', $('#txtEmpId').val());
    model.append('companyName', $('#txtCompanyName').val());
    model.append('verificationCode', $('#txtCode').val());
    $.ajax({
        type: 'post',
        contentType: 'application/json',
        url: 'Empvalidate/EmploymentVerification',
        data: model,
        contentType: false,
        processData: false,
        success: function (result) {
            debugger;
            console.log('success: ' + JSON.stringify(result));
            if (result.isVerified == true) {
                $('#spnResult').text('Verified!');
                $('#spnResult').css('color', 'green');
                emptyDetails();
            } else {
                $('#spnResult').text('Not Verified!');
                $('#spnResult').css('color', 'red');
                emptyDetails();
            }
        },
        error: function (err) {
            debugger;
            console.log('error: ' + err);
        }
    })
});

function emptyDetails() {
    $('#txtEmpId').val('');
    $('#txtCompanyName').val('')
    $('#txtCode').val('');
}
