import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SongsApiService {

  baseUrl: string = "https://localhost:7235"
  constructor(private http: HttpClient) { }

  getSongs():Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/Song`);
  }

  getAlbumList():Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/Album`);
  }

  getAlbum($name: string):Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/Album/${$name}`)
  }

  getAlbumFull($name: string):Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/Album/x/${$name}`)
  }
}
