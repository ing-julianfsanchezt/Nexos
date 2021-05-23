import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BibliotecaComponent } from './components/biblioteca/biblioteca.component';
import { LibrosComponent } from './components/biblioteca/libros/libros.component';
import { ListComponent } from './components/biblioteca/list/list.component';
import { BusquedaComponent } from './components/biblioteca/busqueda/busqueda.component';

@NgModule({
  declarations: [
    AppComponent,
    BibliotecaComponent,
    LibrosComponent,
    ListComponent,
    BusquedaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
