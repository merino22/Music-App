import { DatePipe } from '@angular/common';
import { AfterViewChecked, Component, Input, OnInit } from '@angular/core';
import { Album } from '../models/album';

@Component({
  selector: 'app-left-panel',
  templateUrl: './left-panel.component.html',
  styleUrls: ['./left-panel.component.css']
})
export class LeftPanelComponent implements AfterViewChecked {

  @Input() albumInfo?: any;
  convertedDate?: string;

  constructor() { }

  ngAfterViewChecked(): void {
    this.convertedDate = new Date(this.albumInfo.releaseDate).toLocaleString();
    console.log(this.convertedDate);
  }

  // printDate() {
  //   console.log(this.albumInfo.releaseDate)
  // }

}
