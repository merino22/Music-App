import { Component, OnInit } from '@angular/core';
import { Album } from '../models/album';
import { SongsApiService } from '../services/songs-api.service';

@Component({
  selector: 'app-album-list',
  templateUrl: './album-list.component.html',
  styleUrls: ['./album-list.component.css']
})
export class AlbumListComponent implements OnInit {

  albumList: Array<Album> = [];
  selectedAlbum?: Album;

  constructor(private songsApiSvc: SongsApiService) { }

  ngOnInit(): void {
    this.songsApiSvc.getAlbumList().subscribe( res => {
      this.albumList = res;
    })
  }

  onClick(album: Album): void {
    this.selectedAlbum = album;
  }

}
