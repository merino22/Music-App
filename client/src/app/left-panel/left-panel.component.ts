import { AfterViewChecked, Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-left-panel',
  templateUrl: './left-panel.component.html',
  styleUrls: ['./left-panel.component.css']
})
export class LeftPanelComponent implements OnInit, AfterViewChecked {

  @Input() albumInfo?: any;
  convertedDate?: string;
  currentRate: number = 0;
  constructor() { }

  ngOnInit(): void {
  }

  ngAfterViewChecked(): void {
    this.convertedDate = new Date(this.albumInfo.releaseDate).toLocaleString();
    console.log(this.convertedDate);
  }

  // printDate() {
  //   console.log(this.albumInfo.releaseDate)
  // }

}
