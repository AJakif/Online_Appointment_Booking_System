$(document).ready(function () {
    $('table .prescription').on('click', function () {
        var id = $(this).data("id");

        $('#Record #id').val(id);
    })

});

function Visit(url) {
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

function Patient(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (response) {
            console.log(response)
            var res = response.data;
            if (res != null) {
                swal.fire({
                    title: "Patient Details",
                    html: `
                            <div class="text-left">
                            <p><b>Appoinment ID:</b> ${res.appointmentId}</p>
                            <p><b>Patient Name:</b> ${res.patientName} </p>
                            <p><b>Symptom:</b> ${res.symptom} </p>
                            <p><b>Medication:</b> ${res.medication} </p>
                            </div>`
                })
            }
            else {
                toastr["error"](data.message);
            }
        }
    });
};


function Details(url) {

    $.ajax({
        type: 'POST',
        url: url,
        success: function (response) {
            console.log(response)
            var res = response.data;
            if (res != null) {
                swal.fire({
                    title: "Appointment Details",
                    html: `
                            <div class="text-left">
                            <p><b>Appoinment ID:</b> ${res.appointmentId}</p>
                            <p><b>Patient Name:</b> ${res.patientName} </p>
                            <p><b>Symptom:</b> ${res.symptom} </p>
                            <p><b>Medication:</b> ${res.medication} </p>
                            <p><b>Desis:</b> ${res.diesis} </p>
                            <p><b>Prescription :</b> ${res.prescription} </p>
                            </div>`
                })
            }
            else {
                toastr["error"](data.message);
            }
        }
    });
};
