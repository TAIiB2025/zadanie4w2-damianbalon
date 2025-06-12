import { Component, inject } from '@angular/core';
import { ListaService } from '../lista.service';
import { Observable } from 'rxjs';
import { Usluga } from '../../models/usluga';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-lista',
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent {
  private readonly listaService = inject(ListaService);
  public dane$: Observable<Usluga[]>;
  public fraza: string = '';

  constructor() {
    this.dane$ = this.listaService.get();
  }

  filtruj() {
    this.dane$ = this.listaService.get(this.fraza);
  }
}

