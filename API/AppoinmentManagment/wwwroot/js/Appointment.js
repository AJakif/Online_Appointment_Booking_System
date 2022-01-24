$(document).ready(function () {

    var specializationId = document.getElementById('specialization');
    var doctorId = document.getElementById('doctor')
    specializationId.innerHTML = "";
    

    $.ajax({
        type: 'GET',
        url: '/specialization/all',
        datatype: 'JSON',
        success: function (response) {
            let specialArray = [];
            let specializationData = response.data;
            let len = specializationData.length;
            for (let i = 0; i < len; i++) {
                specialArray.push(specializationData[i]);
            }

            for (var special in specialArray) {
                let newSpecial = document.createElement("option");
                newSpecial.value = (specialArray[special].oId);
                newSpecial.innerHTML = (specialArray[special].specialiaztion);
                specializationId.options.add(newSpecial);
            }
            doctorname(specializationId.value, doctorId);
        }
    });
});


function doctorname(s1, d1) {
    $.ajax({
        type: 'GET',
        url: '/getdoctor/' + s1,
        datatype: 'JSON',
        success: function (response) {
            let doctorArray = [];
            let doctorData = response.data;
            let len = doctorData.length;
            for (let i = 0; i < len; i++) {
                doctorArray.push(doctorData[i]);
            }

            for (var doctor in doctorData) {
                let newDoctor = document.createElement("option");
                console.log(doctorData[doctor].drId)
                newDoctor.value = (doctorData[doctor].drId);
                newDoctor.innerHTML = (doctorData[doctor].name);
                d1.options.add(newDoctor);
            }
        }
    });
}

function HandleChange(s1, s2) {
    var specializationValue = document.getElementById(s1).value;
    var doctorId = document.getElementById(s2);
    doctorId.innerHTML = "";
    doctorname(specializationValue, doctorId);
}