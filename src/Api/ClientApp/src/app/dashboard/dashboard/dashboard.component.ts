import { Component, OnInit } from '@angular/core';
import { InquiryService } from '../../inquiry.service';
import { Chart } from 'angular-highcharts';

import { SeriesOptions } from 'highcharts';
import { KeyValuePair } from '../../models/keyvaluepair';
import { KeyValue } from '@angular/common';
import { User } from '../../models/user';
import { InquiredModel } from '../../models/inquiredmodel';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  inquiredMonthlyChart = new Chart({
    chart: {
      type: 'line'
    },
    title: {
      text: 'Products Inquired Based on Month'
    },
    subtitle: {
      text: 'Year 2018'
    },
    credits: {
      enabled: false
    },
    yAxis: {
      title: {
        text: 'Number of Inquiries'
      }
    },
    xAxis: {
      title: {
        text: 'Month in Index'
      },
      
    }
  });
  chart = new Chart({
    chart: {
      type: 'pie'
    },
    title: {
      text: 'Product Based'
    },
    credits: {
      enabled: false
    },

  });
  constructor(private inquiryService: InquiryService) { }


  ngOnInit() {
    this.inquiryService.getInquirieReport()
      .subscribe((keyValues: KeyValuePair<number>[]) => {
        this.addSeries(keyValues);
      });
    this.inquiryService.getInquirieMonthlyReport()
      .subscribe(
        (keyValues: KeyValuePair<InquiredModel[]>[]) => {
          console.log(keyValues);
          this.addInquiredMonthlySeries(keyValues);
        },
        (error: any) => { console.log(error) }
      );
  }
  addInquiredMonthlySeries(keyValues: KeyValuePair<InquiredModel[]>[]) {
    let lineChat = this.inquiredMonthlyChart;
    keyValues.forEach(function (keyValue) {
      let series: SeriesOptions = { name: keyValue.key, data: [] };

      keyValue.value.forEach(function (inquiryModel) {
        series.data.push(inquiryModel.productCount);
      });
      lineChat.addSeries(series);
    });

  }
  addSeries(keyValues: KeyValuePair<number>[]) {
    let series: SeriesOptions = { name: "Year 2018", data: [] };

    keyValues.forEach(function (keyValue) {
      series.data.push([keyValue.key, keyValue.value]);
    });
    this.chart.addSeries(series);
  }
}
