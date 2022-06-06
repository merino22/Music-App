import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlbumListComponent } from './album-list/album-list.component';
import { AlbumComponent } from './album/album.component';
import { SongComponent } from './song/song.component';
import { SongsTableComponent } from './songs-table/songs-table.component';

const routes: Routes = [
  { path: '', redirectTo: '/albums', pathMatch: 'full'},
  { path: 'songs',  component:SongComponent},
  { path: 'albums',  component:AlbumListComponent},
  { path: 'album/:id',  component:AlbumComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
