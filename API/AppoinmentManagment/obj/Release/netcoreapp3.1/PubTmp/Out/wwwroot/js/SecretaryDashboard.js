$(document).ready(function () {
    //Patient count Api
    $.ajax({
        type: 'GET',
        url: '/CountPendingAppointment',
        datatype: 'JSON',
        success: function (response) {
            console.log(response);
            let appointment = response.appointment;
            console.log(appointment);
            document.getElementById('appoinmentCount').innerHTML = appointment;
        }
    });
});

function Decline(url) {
 
        $.ajax({
            type: 'POST',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr["success"](data.message);
                    window.location.reload();
                }
                else {
                    toastr["error"](data.message);
                }
            }
        });
}

function Approve(url) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr["success"](data.message)
                    window.location.reload();
                }
                else {
                    toastr["error"](data.message);
                }
            }
        });
}


