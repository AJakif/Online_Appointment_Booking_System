import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { AdminApiService } from '../_services/admin-api.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  Highcharts: typeof Highcharts = Highcharts;
  chartOptions!: Highcharts.Options;
  barOptions!: Highcharts.Options;

  patientCount!:number;
  DoctorCount!:number;
  specialCount!:number;
  balance!:number;
  series!:any;
  sYear:any = 2021;

  constructor(private adminService : AdminApiService) { }

  ngOnInit(): void {
    this.showPatientCounts();
    this.showDoctorCounts();
    this.showSpecializationCounts();
    this.showBalance();
    this.piechart();
    this.linechart();

  }

  public piechart(){

    this.adminService.doctors().subscribe(
      (response:any)=>{
        let e = response;
        let amount = [];
        let month = [];
        let len = response.length;

        for (var i = 0; i < len; i++) {
          amount.push(e[i].amount);
          month.push(e[i].month);
      }
      var Array = []

      for (var i = 0; i < len; i++) {
        Array.push([ 
            month[i],
            amount[i]
          ])
      }
      this.chartOptions = {   
        chart : {
           plotShadow: false
        },
        title : {
           text: 'Browser market shares at a specific website, 2014'   
        },
        tooltip : {
           pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        accessibility: {
          point: {
              valueSuffix: '%'
          }
      },
        plotOptions : {
           pie: {
              allowPointSelect: true,
              cursor: 'pointer',
        
              dataLabels: {
                enabled: true,
                format: '<b>{point.name}</b>: {point.percentage:.1f} %'           
              },
        
              showInLegend: false
           }
        },
        series : [{
           type: 'pie',
           name: 'Total Amount',
           data: Array
        }]
     };
      },
      (error)=>{
        console.log(error);
      }
    );
   


    
  }
  public linechart(){

    this.barOptions = {
      title: {
        text: `Yearly deposit, ${this.sYear} - current year`
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
            pointStart: this.sYear
        }
    },
  
    series: [{
      name: 'Tokyo',
      type: 'spline',
      data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2,26.5, 23.3, 18.3, 13.9, 9.6]
   },
   {
      name: 'New York',
      type: 'spline',
      data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8,24.1, 20.1, 14.1, 8.6, 2.5]
   },
   {
      name: 'Berlin',
      type: 'spline',
      data: [-0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0]
   },
   {
      name: 'London',
      type: 'spline',
      data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
   }],
  
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
  
  };
  }

  

  public showPatientCounts()
  {
    this.adminService.patients().subscribe(
      (response:any)=>{
        this.patientCount = response.patient
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
  public showDoctorCounts()
  {
    this.adminService.doctors().subscribe(
      (response:any)=>{
        this.DoctorCount = response.doctor
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
  public showSpecializationCounts()
  {
    this.adminService.specializations().subscribe(
      (response:any)=>{
        this.specialCount = response.special
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
  public showBalance()
  {
    this.adminService.balance().subscribe(
      (response:any)=>{
        this.balance = response.balance
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
}
