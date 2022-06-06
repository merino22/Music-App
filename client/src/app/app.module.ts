import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SongsTableComponent } from './songs-table/songs-table.component';
import { HttpClientModule } from '@angular/common/http';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { AlbumComponent } from './album/album.component';
import { AlbumListComponent } from './album-list/album-list.component';
import { SongComponent } from './song/song.component';
import { LeftPanelComponent } from './left-panel/left-panel.component';
import { TopPanelComponent } from './top-panel/top-panel.component';
import { FilterTextboxComponent } from './filter-textbox/filter-textbox.component';
import { FormsModule } from '@angular/forms';
import { StarRatingModule } from 'angular-star-rating';
import { NgxStarRatingModule } from 'ngx-star-rating';

@NgModule({
  declarations: [
    AppComponent,
    SongsTableComponent,
    AlbumComponent,
    AlbumListComponent,
    SongComponent,
    LeftPanelComponent,
    TopPanelComponent,
    FilterTextboxComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    NgxStarRatingModule,
    StarRatingModule.forRoot()
  ],
  providers: [{provide: LocationStrategy, useClass: HashLocationStrategy}], // Fallback de URL para que no tira 404 al hacer reload
  bootstrap: [AppComponent]
})
export class AppModule { }
