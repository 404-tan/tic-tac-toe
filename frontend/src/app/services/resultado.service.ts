import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.dev';
import { Resultado } from '../models/resultado';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UltimosVencedoresResponse } from '../models/ultimos-vencedores-response';

@Injectable({
  providedIn: 'root',
})
export class ResultadoService {
  resultadoEndpoint = environment.apiUrl + '/resultados';
  private http = inject(HttpClient);
  constructor() {}
  getUltimosVencedores(): Observable<UltimosVencedoresResponse>{
    return this.http.get<UltimosVencedoresResponse>(`${this.resultadoEndpoint}/ultimos`);
  }
  postResultado(vencedor: string){
    return this.http.post<Resultado>(this.resultadoEndpoint, {vencedor: vencedor});
  }
}
