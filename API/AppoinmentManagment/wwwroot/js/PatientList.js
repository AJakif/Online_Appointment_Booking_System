$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '/GetAllPatient',
        datatype: 'JSON',
        success: function (response) {

            let patientData = response.data;
            console.log(patientData);
            loadTableData(patientData);
        }
    });
});

function loadTableData(patientData) {
    const tableBody = document.getElementById('tableData');
    let dataHtml = '';
    var result = 0;
    for (var prop in patientData) {
        if (patientData.hasOwnProperty(prop)) {
            result++;
        }
    }
    console.log("length =", result);
    if (result == 0) {
        dataHtml += `<tr>
                            <td colspan="9" style="text-align:center">No data</td>
                        </tr>`;
        tableBody.innerHTML = dataHtml;
        $('#dtBasicExample').DataTable();
    }
    else {
        for (let patient of patientData) {

            dataHtml += `<tr>
                           <td class="text-center">${patient.name}</td>
                           <td class="text-center">${patient.phone}</td>
                           <td class="text-center">${patient.address}</td>
                           <td class="text-center">${patient.dob}</td>
                           <td class="text-center"><div class="text-center">
                                <a class="btn btn-success text-white edit" style="cursor:pointer; width:100px;" data-toggle="modal" data-target="#EditRecord" data-id="@trans.OId">
                                    <i class='far fa-edit'></i>
                                </a>
                                <a onclick=Delete("/Home/Transaction/Delete/@trans.OId") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                    <i class='far fa-trash-alt'></i>
                                </a>
                            </div></td>
                         </tr>`;


            tableBody.innerHTML = dataHtml;
        }
    }

    $('#dtBasicExample').DataTable();
    $('.dataTables_length').addClass('bs-select');

}