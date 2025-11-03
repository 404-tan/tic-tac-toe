import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root' // Disponível em toda a aplicação
})
export class ResultadoNotificationService {
  private resultadoGravadoSource = new Subject<void>();

  resultadoGravado$ = this.resultadoGravadoSource.asObservable();

  notificarNovoResultado() {
    this.resultadoGravadoSource.next();
  }
}
