$(document).ready(function () {
    $('table .edit').on('click', function () {
        var id = $(this).data("id");

        $.ajax({
            type: 'POST',
            url: '/payment',
            data: { "id": id },
            success: function (response) {
                $('#EditRecord #amount').val(response.fee);
                $('#EditRecord #id').val(response.appointment);

            }
        })
    });
});

function Details(url) {

    $.ajax({
        type:'POST',
        url: url,
        success: function (response) {
            console.log(response)
            var res = response.data;
            if (res != null) {
                swal.fire({
                    title: "Details",
                    html: `<div class="text-left">
                            <p><b>Appoinment ID:</b> ${res.appointmentId}</p>
                            <p><b>Doctor Name:</b> ${res.doctorName} </p>
                            <p><b>Symptom:</b> ${res.symptom} </p>
                            <p><b>Medication:</b> ${res.medication} </p>
                            <p><b>Desis:</b> ${res.diesis} </p>
                            <p><b>Prescription :</b> ${res.prescription} </p>
                           </div>`
                })
            }
            else {
                toastr["error"](response.message);
            }
        }
    });
};