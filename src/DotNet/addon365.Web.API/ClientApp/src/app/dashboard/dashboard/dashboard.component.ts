import { Component, OnInit, ChangeDetectorRef, ViewChild } from "@angular/core";
import { InquiryService } from "../../inquiry.service";

import { InquiryReport } from "src/app/models/inquiry-report";
import { UniqueSelectionDispatcher } from "@angular/cdk/collections";
import { Dictionary } from "src/app/utils/dictionary";


@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.css"]
})
export class DashboardComponent implements OnInit {
  constructor(private inquiryService: InquiryService,
    private cd: ChangeDetectorRef) { }
  selectedYear: string;
  years: string[];
  chartData: Array<Array<any>>;
  pieChartData = {
    chartType: "PieChart",
    dataTable: null,
    options: {
      title: "Tasks",
      legend: { position: 'bottom', alignment: 'start' },
      width: 420,
      height: 350
    }
  };
  @ViewChild("yearChartId") yearChartCtl;
  tableChart = {
    chartType: "Table",
    dataTable: null,
    options: {
      title: "Top Year",
      width: 420,
      height: 350
    }
  };


  yearChartData = {
    chartType: "BarChart",
    dataTable: null,
    options: {
      title: "Top Chart",
      legend: { position: 'bottom', alignment: 'start' },
      width: 520,
      height: 350,
      forceRedrawNow: true
    }
  };


  lineChart = {
    chartType: "LineChart",
    dataTable: null,
    options: {
      title: "Line Chart",
      legend: { position: 'bottom', alignment: 'start' },
      width: 520,
      height: 350
    }
  };
  ngOnInit() {
    this.inquiryService
      .get("name")
      .subscribe((keyValues: InquiryReport[]) => {
        this.updateChart(keyValues);
      });

    this.inquiryService.get("year")
      .subscribe((keyValues: InquiryReport[]) => {
        this.updateYearSelector(keyValues);
        this.updateYear(keyValues);
      });
  }

  updateYearSelector(arrInquiry: InquiryReport[]) {
    this.years = Array.from(new Set<string>(arrInquiry.map(x =>
      new Date(x.date).getFullYear().toString()
    )));
  }
  updateYear(arrInquiryReport: InquiryReport[]) {
    let dictData = new Dictionary<number[]>();
    const names: string[] = Array.from(new Set<string>(arrInquiryReport.map(x => x.name)));

    let headers = names;
    headers.splice(0, 0, "Year");
    arrInquiryReport.forEach(value => {
      let year: string = new Date(value.date).getFullYear().toString();
      let index = names.indexOf(value.name);
      if (dictData.containsKey(year)) {
        dictData.get(year).splice(index, 0, value.count);
      } else {
        dictData.add(year, [])
        dictData.get(year).splice(index, 0, value.count);
      }

    });
    this.dictToData(dictData, headers);
  }
  dictToData(dictData: Dictionary<number[]>, headers: string[]) {
    this.chartData = new Array<Array<any>>();
    this.chartData.push(headers);
    dictData.keys().forEach(key => {
      let arr = [];
      arr.push(key);
      arr = arr.concat(dictData.get(key));
      this.chartData.push(arr);
    });
    this.yearChartData.dataTable = this.chartData;
    this.tableChart.dataTable = this.chartData;
    this.lineChart.dataTable = this.chartData;
  }
  updateChart(arrInquiryReport: InquiryReport[]) {
    let chartData = new Array<Array<any>>();
    let header = ["Name", "Count"];
    chartData.push(header);
    arrInquiryReport.forEach(value => {
      let inquiryReportObj = new InquiryReport();
      inquiryReportObj.copyFrom(value)
      chartData.push(inquiryReportObj.toArray());
    });
    this.pieChartData.dataTable = chartData;
  }
  inquiryReportToArray(inquiryReport: InquiryReport) {
    let inquiryReportData = new Array<any>();
    inquiryReportData.push(inquiryReport.name);
    inquiryReportData.push(inquiryReport.count);
    return inquiryReportData;
  }
  onYearChanged(event: any) {
    var dataTable = this.chartData.slice();
    this.chartData.forEach((item, index) => {
      if (this.selectedYear.localeCompare(item[0]) != 0) {
        this.chartData = dataTable.splice(0, index);
        console.log("GOT-" + dataTable);
        this.yearChartData.dataTable = dataTable.slice();
        this.tableChart.dataTable = dataTable.slice();
        this.yearChartData.options.forceRedrawNow = true;
        console.log(this.yearChartCtl);
        this.yearChartCtl.redraw();
        return;
      }

    });


  }
}
