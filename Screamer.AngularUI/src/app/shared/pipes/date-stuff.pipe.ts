import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';

@Pipe({
  name: 'dateStuff',
})
export class DateStuffPipe implements PipeTransform {
  private datePipe: DatePipe;

  constructor() {
    this.datePipe = new DatePipe('en-US');
  }

  transform(value: string, format: string): string {
    const date = moment(value).subtract(1, 'hours').toDate();
    return this.datePipe.transform(date, 'yyyy-MM-dd HH:mm:ss') as string;
  }
}
