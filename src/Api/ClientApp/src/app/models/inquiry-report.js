"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var InquiryReport = /** @class */ (function () {
    function InquiryReport() {
    }
    InquiryReport.prototype.toArray = function () {
        var array = new Array();
        array.push(this.name);
        if (!this.date)
            array.push(this.date);
        array.push(this.count);
        return array;
    };
    InquiryReport.prototype.copyFrom = function (obj) {
        this.name = obj.name;
        if (!this.date) {
            console.log(obj.date);
            this.date = obj.date;
            console.log(this.date instanceof Date);
        }
        this.count = obj.count;
    };
    return InquiryReport;
}());
exports.InquiryReport = InquiryReport;
//# sourceMappingURL=inquiry-report.js.map