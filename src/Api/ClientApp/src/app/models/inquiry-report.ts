export class InquiryReport {
  id: number;
  name: string;
  date: Date;
  count: number;

  toArray() {
    let array = new Array<any>();
    array.push(this.name);
    if (!this.date)
      array.push(this.date);
    array.push(this.count);
    return array;
  }
  copyFrom(obj: InquiryReport) {
    this.name = obj.name;
    if (!this.date) {
      this.date = new Date(obj.date);
    }
    this.count = obj.count;
  }

 
}


