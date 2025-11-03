import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, resource, signal } from '@angular/core';
import { Resultado } from '../../models/resultado';
import { ResultadoService } from '../../services/resultado.service';
import { rxResource, takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ResultadoNotificationService } from '../../services/resultado-notification.service';

@Component({
  selector: 'app-activity-board',
  imports: [CommonModule],
  templateUrl: './activity-board.html',
  styleUrl: './activity-board.css',
})
export class ActivityBoard implements OnInit {
  private resultadoService = inject(ResultadoService);
  private notificationService = inject(ResultadoNotificationService);
  resultadosRecentes = rxResource({
    stream: () => this.resultadoService.getUltimosVencedores()
  });
  constructor(){
    this.notificationService.resultadoGravado$
            .pipe(takeUntilDestroyed())
            .subscribe(() => {
                this.resultadosRecentes.reload()
            });
  }
  ngOnInit() {

  }


}
