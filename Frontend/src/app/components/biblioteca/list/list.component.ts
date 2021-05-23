import { Component, OnInit } from '@angular/core';
import { BibliotecaService } from 'src/app/services/biblioteca.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(public bibliotecaService: BibliotecaService) { }

  ngOnInit(): void {
    this.bibliotecaService.obtenerLibros();
  }

}
