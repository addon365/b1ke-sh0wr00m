import { Component, OnInit } from '@angular/core';
import { InquiryService } from '../../inquiry.service';
import { Chart } from 'angular-highcharts';

import { SeriesOptions } from 'highcharts';
import { KeyValuePair } from '../../models/keyvaluepair';
import { KeyValue } from '@angular/common';
import { User } from '../../models/user';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

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
      .subscribe((keyValues: KeyValuePair[]) => {
        this.addSeries(keyValues);
      });
  }
  addSeries(keyValues: KeyValuePair[]) {
    let data: [[string, number]];
    let series: SeriesOptions = { name: "Year 2018", data: [] };

    keyValues.forEach(function (keyValue) {
      series.data.push([keyValue.name, keyValue.value]);
    });
    this.chart.addSeries(series);
  }
}
