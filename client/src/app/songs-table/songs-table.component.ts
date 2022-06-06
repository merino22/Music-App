import { Component, Directive, Input, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventEmitter } from '@angular/core';
import { Album } from '../models/album';
import { Song } from '../models/song';
import { SongsApiService } from '../services/songs-api.service';

@Component({
  selector: 'app-songs-table',
  templateUrl: './songs-table.component.html',
  styleUrls: ['./songs-table.component.css']
})
export class SongsTableComponent implements OnInit {

  @Input() songsList: Array<Song> = [];
  name: string = "";

  constructor(private songApiSvc: SongsApiService, private route: ActivatedRoute) { }

  ngOnInit(): void {

  }
}
