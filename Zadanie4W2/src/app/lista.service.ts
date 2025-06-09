import { Injectable } from '@angular/core';
import { Usluga } from '../models/usluga';
import { Observable, of } from 'rxjs';
import { UslugaBody } from '../models/usluga-body';

@Injectable({
  providedIn: 'root'
})
export class ListaService {
  private static idGen = 1;

  private lista: Usluga[] = [
  { id: ListaService.idGen++, nazwa: "Malowanie ścian", wykonawca: "Jan Kowalski", rodzaj: "Budowlana", rok: 2023 },
  { id: ListaService.idGen++, nazwa: "Naprawa laptopa", wykonawca: "TechFix Serwis", rodzaj: "Elektroniczna", rok: 2024 },
  { id: ListaService.idGen++, nazwa: "Projekt ogrodu", wykonawca: "Zielony Zakątek", rodzaj: "Projektowa", rok: 2022 },
  { id: ListaService.idGen++, nazwa: "Tłumaczenie dokumentów", wykonawca: "Anna Nowak", rodzaj: "Językowa", rok: 2021 },
  { id: ListaService.idGen++, nazwa: "Kurs programowania", wykonawca: "CodeAcademy", rodzaj: "Edukacyjna", rok: 2025 }
];

  get(): Observable<Usluga[]> {
    return of(this.lista);
  }

  getByID(id: number): Observable<Usluga> {
    const ksiazka = this.lista.find(k => k.id === id);
    if(ksiazka == null) {
      throw new Error('Nie znaleziono wskazanej książki');
    }
    return of(ksiazka);
  }

  delete(id: number): Observable<void> {
    this.lista = this.lista.filter(k => k.id !== id);
    return of(undefined);
  }

  put(id: number, body: UslugaBody): Observable<void> {
    const ksiazka = this.lista.find(k => k.id === id);
    if(ksiazka == null) {
      throw new Error('Nie znaleziono wskazanej książki');
    }

    ksiazka.wykonawca = body.wykonawca;
    ksiazka.rodzaj = body.rodzaj;
    ksiazka.rok = body.rok;
    ksiazka.nazwa = body.nazwa;

    return of(undefined);
  }

  post(body: UslugaBody): Observable<void> {
    const ksiazka: Usluga = {
      id: ListaService.idGen++,
      wykonawca: body.wykonawca,
      rodzaj: body.rodzaj,
      rok: body.rok,
      nazwa: body.nazwa
    };

    this.lista.push(ksiazka);

    return of(undefined);
  }
}
