$(document).ready(function () {
    monthly();
    //Patient count Api
    $.ajax({
        type: 'GET',
        url: '/CountPatient',
        datatype: 'JSON',
        success: function (response) {
            let patient = response.patient;
            document.getElementById('patientCount').innerHTML = patient;
        }
    });

    //Doctor Count Api
    $.ajax({
        type: 'GET',
        url: '/CountDoctor',
        datatype: 'JSON',
        success: function (response) {
            let doctor = response.doctor;
            document.getElementById('doctorCount').innerHTML = doctor;
        }
    });

    //Doctor Count Api
    $.ajax({
        type: 'GET',
        url: '/CountSpecialization',
        datatype: 'JSON',
        success: function (response) {
            let doctor = response.special;
            document.getElementById('specializationCount').innerHTML = doctor;
        }
    });

    $.ajax({
        type: 'GET',
        url: '/Balance',
        datatype: 'JSON',
        success: function (response) {
            let balance = response.balance;
            document.getElementById('balance').innerHTML = "$"+balance;
        }
    });
});

function monthly() {

    document.getElementById("report").innerHTML = `<div class="row" >
                                                            <div class= "col-6 border" id="deposit" >
                                                                <figure class="highcharts-figure" >
                                                                    <div id="container"></div>
                                                                    <p class="highcharts-description">
                                                                    </p>
                                                                </figure>
                                                            </div >
                                                            <div class="col-6 border">
                                                                <figure class="highcharts-figure">
                                                                    <div id="linechart1"></div>
                                                                    <p class="highcharts-description">

                                                                    </p>
                                                                </figure>
                                                            </div>
                                                        </div >`


    /* deposit pie*/
    MonthDepositChange()
}


function MonthDepositChange() {
    
    /* deposit pie*/
    $.ajax({
        /* ajax start*/
        url: '/admin/Report/monthlyDeposit/' ,
        type: 'GET',
        dataType: 'JSON',
        success: function (json) {

            let e = json;
            var amount = [];
            var month = [];
            var len = e.length;

            for (var i = 0; i < len; i++) {
                amount.push(e[i].amount);
                month.push(e[i].month);
            }
            var A = []

            for (var i = 0; i < len; i++) {
                A.push({
                    name: month[i],
                    y: amount[i]
                })
            }
            /*Highcharts using here.. PIE CHART*/
            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: `All Deposit of <b>Current Year</b>`
                },
                tooltip: {
                    pointFormat: 'Ratio: <b>{point.percentage:.1f}%</b> <br /> {series.name}: <b>{point.y:.1f}$</b>'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                        }
                    }
                },
                series: [{
                    name: 'Total Amount',
                    colorByPoint: true,
                    data: A
                }]
            });

        },
        Error: function (json) {
            console.log(json)
        }
        /* ajax end*/
    })

    $.ajax({
        /* ajax start*/
        url: '/admin/Report/yearlyDeposit',
        type: 'GET',
        dataType: 'JSON',
        success: function (remarkList) {
            var A = []
            console.log(remarkList);
            for (var i = 0; i < remarkList.length; i++) {
                var total = [];
                let remark = remarkList[i].month;
                for (var j = 0; j < remarkList[i].list.length; j++) {

                    total.push(remarkList[i].list[j].total)
                }
                A.push({
                    name: remark,
                    data: total
                })

            }
            var sYear = parseInt(remarkList[0].list[0].year);
            /*var fYear = parseInt(remarkList[0].list[4].year);*/

            /*Highcharts using here.. Line CHART*/
            Highcharts.chart('linechart1', {

                title: {
                    text: `Yearly deposit, ${sYear} - current year`
                },

                yAxis: {
                    title: {
                        text: 'Total deposit amount'
                    }
                },

                xAxis: {
                    accessibility: {
                        rangeDescription: 'Range: ${sYear} to current year'
                    }
                },

                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                plotOptions: {
                    series: {
                        label: {
                            connectorAllowed: false
                        },
                        pointStart: sYear
                    }
                },

                series: A,

                responsive: {
                    rules: [{
                        condition: {
                            maxWidth: 500
                        },
                        chartOptions: {
                            legend: {
                                layout: 'horizontal',
                                align: 'center',
                                verticalAlign: 'bottom'
                            }
                        }
                    }]
                }

            });

        },
        Error: function (remarkList) {
            console.log(remarkList)
        }
        /* ajax end*/
    })
}