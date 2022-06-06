import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Album } from '../models/album';
import { Song } from '../models/song';
import { SongsApiService } from '../services/songs-api.service';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export class AlbumComponent implements OnInit {

  constructor(private songApiSvc: SongsApiService, private route: ActivatedRoute) { }

  name: string = "";
  albumInfo?: Album;
  songsList: Array<Song> = [];

  ngOnInit(): void {
    this.name = this.route.snapshot.paramMap.get('id')!;
    this.songApiSvc.getAlbumFull(this.name).subscribe(res => {
      this.albumInfo = res.value;
      this.songsList = res.value.songs;
      console.table(this.albumInfo)
    })
  }

}
