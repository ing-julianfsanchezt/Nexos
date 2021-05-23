import { Component, OnInit } from '@angular/core';
import { BibliotecaService } from 'src/app/services/biblioteca.service';
import { FormsModule, ReactiveFormsModule, FormGroup, FormBuilder, Validators } from "@angular/forms";
import { libroModel } from 'src/app/models/libroModel';


@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.css']
})
export class LibrosComponent implements OnInit {

  form!: FormGroup;
  constructor(private formBuilder: FormBuilder , public bibliotecaService: BibliotecaService) { 
    this.form = this.formBuilder.group({
      id: 0,
      titulo:['',[Validators.required, Validators.maxLength(50), Validators.minLength(1)]],
      anio:['',[Validators.required, Validators.maxLength(4), Validators.minLength(4)]],
      genero:['',[Validators.required, Validators.maxLength(20), Validators.minLength(1)]],
      numPaginas:['',[Validators.required, Validators.maxLength(5), Validators.minLength(1)]],
      idEditorial:['',[Validators.required, Validators.maxLength(5), Validators.minLength(1)]],
      idAutor:['',[Validators.required, Validators.maxLength(5), Validators.minLength(1)]]
    });
  }

  ngOnInit(): void {
    this.bibliotecaService.obtenerEditoriales();
    this.bibliotecaService.obtenerAutores();
  }

  registrarLibro(){
    const libro: libroModel = {
      idLibro: 0,
      titulo: this.form.get('titulo')?.value,
      anio: this.form.get('anio')?.value.toString(),
      genero: this.form.get('genero')?.value,
      numPaginas: this.form.get('numPaginas')?.value,
      idEditorial: this.form.get('idEditorial')?.value.toString(),
      idAutor: this.form.get('idAutor')?.value.toString()
    }
    console.log(libro);
    this.bibliotecaService.registrarLibro(libro).subscribe(data => {
      console.log("Guardado");
      this.form.reset();
    });
  }
}
