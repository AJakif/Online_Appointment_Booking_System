import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { AdminApiService } from '../_services/admin-api.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit {
  Highcharts: typeof Highcharts = Highcharts;
  chartOptions!: Highcharts.Options;
  barOptions : any

  patientCount!: number;
  DoctorCount!: number;
  specialCount!: number;
  balance!: number;
  series!: any;

  constructor(private adminService: AdminApiService) {}

  ngOnInit(): void {
    this.showPatientCounts();
    this.showDoctorCounts();
    this.showSpecializationCounts();
    this.showBalance();
    this.piechart();
    this.linechart();
  }

  public piechart() {
    this.adminService.monthlyDeposit().subscribe(
      (response: any) => {
        let e = response;
        let amount = [];
        let month = [];
        let len = response.length;

        for (var i = 0; i < len; i++) {
          amount.push(e[i].amount);
          month.push(e[i].month);
        }
        var Array = [];

        for (var i = 0; i < len; i++) {
          Array.push([month[i], amount[i]]);
        }
        this.chartOptions = {
          chart: {
            plotShadow: false,
          },
          title: {
            text: 'All Deposit of <b>Current Year</b>',
          },
          tooltip: {
            pointFormat:
              'Ratio: <b>{point.percentage:.1f}%</b> <br /> {series.name}: <b>{point.y:.1f}$</b>',
          },
          accessibility: {
            point: {
              valueSuffix: '%',
            },
          },
          plotOptions: {
            pie: {
              allowPointSelect: true,
              cursor: 'pointer',

              dataLabels: {
                enabled: true,
                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
              },

              showInLegend: false,
            },
          },
          series: [
            {
              type: 'pie',
              name: 'Total Amount',
              data: Array,
            },
          ],
        };
      },
      (error) => {
        console.log(error);
      }
    );
  }
  public linechart() {
    this.adminService.yearlyDeposit().subscribe(
      (response: any) => {
        var A = [];
        for (var i = 0; i < response.length; i++) {
          var total = [];
          let remark = response[i].month;
          for (var j = 0; j < response[i].list.length; j++) {
            total.push(response[i].list[j].total);
          }
          A.push({
            name: remark,
            type: 'spline',
            data: total,
          });
        }
        var sYear = parseInt(response[0].list[0].year);

        this.barOptions = {
          chart: {
            type: 'column'
          },
          title: {
            text: `Yearly deposit, ${sYear} - current year`,
          },

          yAxis: {
            title: {
              text: 'Total deposit amount',
            },
          },

          xAxis: {
            accessibility: {
              rangeDescription: `Range: ${sYear} to current year`,
            },
          },

          legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
          },

          plotOptions: {
            series: {
              label: {
                connectorAllowed: false,
              },
              pointStart: sYear,
            },
          },

          series: A,

          responsive: {
            rules: [
              {
                condition: {
                  maxWidth: 500,
                },
                chartOptions: {
                  legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'bottom',
                  },
                },
              },
            ],
          },
        };
      },
      (error) => {
        console.log(error);
      }
    );
  }

  public showPatientCounts() {
    this.adminService.patients().subscribe(
      (response: any) => {
        this.patientCount = response.patient;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  public showDoctorCounts() {
    this.adminService.doctors().subscribe(
      (response: any) => {
        this.DoctorCount = response.doctor;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  public showSpecializationCounts() {
    this.adminService.specializations().subscribe(
      (response: any) => {
        this.specialCount = response.special;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  public showBalance() {
    this.adminService.balance().subscribe(
      (response: any) => {
        this.balance = response.balance;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
