import { Component, inject } from '@angular/core';
import { ListaService } from '../lista.service';
import { Observable } from 'rxjs';
import { Usluga } from '../../models/usluga';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-lista',
  imports: [CommonModule, RouterLink],
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent {
  private readonly listaService = inject(ListaService);
  public dane$: Observable<Usluga[]>;

  constructor() {
    this.dane$ = this.listaService.get();
  }
}
