import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { libroModel } from '../models/libroModel';
import { editorialModel } from '../models/editorialModel';
import { autorModel } from '../models/autorModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BibliotecaService {

  AppUrl = 'https://localhost:44339/';
  ApiUrlLibro = 'api/Libro';
  ApiUrlEditorial = 'api/Editorial/';
  ApiUrlAutor = 'api/Autor';
  listlibro: libroModel[] = [];
  listEditorial: editorialModel[] = [];
  listAutor: autorModel[] = [];

  constructor(private http: HttpClient) { }

  registrarLibro(libro: libroModel): Observable<boolean>{
    let body = JSON.stringify(libro);
    
    let headers = new HttpHeaders({'Content-Type':'application/json'});

    return this.http.post<boolean>(this.AppUrl + this.ApiUrlLibro, body, {headers: headers});
    
  }

  obtenerLibros(){
    this.http.get(this.AppUrl + this.ApiUrlLibro).toPromise()
                  .then(data => {
                    this.listlibro = data as libroModel[];
                  });
  }

  obtenerEditoriales(){
    this.http.get(this.AppUrl + this.ApiUrlEditorial).toPromise()
                  .then(data => {
                    this.listEditorial = data as editorialModel[];
                  });
  }

  obtenerAutores(){
    this.http.get(this.AppUrl + this.ApiUrlAutor).toPromise()
                  .then(data => {
                    this.listAutor = data as autorModel[];
                  });
  }
}
