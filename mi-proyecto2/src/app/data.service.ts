import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private emitirEvento = new Subject<void>();

  eventoEmitido$ = this.emitirEvento.asObservable();

  emitir() {
    this.emitirEvento.next();
  }
}
