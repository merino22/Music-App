import { Component, Directive, EventEmitter, Input, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Song } from '../models/song';
import { SongsApiService } from '../services/songs-api.service';


export type SortColumn = keyof Song | '';
export type SortDirection = 'asc' | 'desc' | '';
const rotate: {[key: string]: SortDirection} = { 'asc': 'desc', 'desc': '', '': 'asc' };

const compare = (v1: string | number, v2: string | number) => v1 < v2 ? -1 : v1 > v2 ? 1 : 0;

export interface SortEvent {
  column: SortColumn;
  direction: SortDirection;
}

@Directive({
  selector: 'th[sortable]',
  host: {
    '[class.asc]': 'direction === "asc"',
    '[class.desc]': 'direction === "desc"',
    '(click)': 'rotate()'
  }
})
export class NgbdSortableHeader {

  @Input() sortable: SortColumn = '';
  @Input() direction: SortDirection = '';
  @Output() sort = new EventEmitter<SortEvent>();

  rotate() {
    this.direction = rotate[this.direction];
    this.sort.emit({column: this.sortable, direction: this.direction});
  }
}

@Component({
  selector: 'app-songs-table',
  templateUrl: './songs-table.component.html',
  styleUrls: ['./songs-table.component.css']
})
export class SongsTableComponent implements OnInit {

  @ViewChildren(NgbdSortableHeader) headers?: QueryList<NgbdSortableHeader>;

  songsList: Array<Song> = [];
  name: string = "";

  constructor(private songApiSvc: SongsApiService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.name = this.route.snapshot.paramMap.get('id')!;
    this.songApiSvc.getAlbum(this.name).subscribe(res => {
      this.songsList = res;
      console.log(this.name);
    })
  }

  onSort({column, direction}: SortEvent) {

    // resetting other headers
    this.headers?.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    // sorting countries
    if (direction === '' || column === '') {
      this.songsList = this.songsList;
    } else {
      this.songsList = [...this.songsList].sort((a, b) => {
        const res = compare(a[column], b[column]);
        return direction === 'asc' ? res : -res;
      });
    }
  }

}
