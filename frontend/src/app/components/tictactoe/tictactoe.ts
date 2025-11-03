import { ResultadoService } from './../../services/resultado.service';
import { CommonModule } from '@angular/common';
import { Component, computed, inject, signal } from '@angular/core';
import { ResultadoNotificationService } from '../../services/resultado-notification.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-tictactoe',
  imports: [CommonModule],
  templateUrl: './tictactoe.html',
  styleUrl: './tictactoe.css',
})
export class Tictactoe {
  private resultadoService = inject(ResultadoService);
  private notificationService = inject(ResultadoNotificationService);
  squares = signal(Array<string>(9).fill(''));
  winConditions = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
  ]
  xIsNext = signal(true);
  oIsNext = computed(() => !this.xIsNext());
  gameIsFinished = computed(() => {
    const hasWinner = this.winner() !== null;
    const isBoardFull = this.squares().every(square => square !== '');
    return hasWinner || isBoardFull;
  });
  winner = signal<string | null>(null);
  constructor() {}
  get player() {
    return this.xIsNext() ? 'X' : 'O';
  }
  handleMove(index: number) {
    if (index > 8 || index < 0 || this.winner()) {
      return;
    }
    const currentSquares = this.squares();
    if (currentSquares[index] !== '') return;
    currentSquares[index] = this.player;
    // Atualiza o Signal com uma nova cópia do array para que o compute funcione corretamente
    this.squares.update(currentSquares => {
        const newSquares = [...currentSquares];
        newSquares[index] = this.player;
        return newSquares;
    });
    this.checkForWinner();
    this.xIsNext.set(!this.xIsNext());
  }
  checkForWinner() {
    for (const condition of this.winConditions) {
      const [a, b, c] = condition;
      const currentSquares = this.squares();
      if(
        currentSquares[a] === this.player &&
        currentSquares[a] === currentSquares[b] &&
        currentSquares[a] === currentSquares[c]
      ) {
        this.winner.set(this.player);
        this.sendResult(this.player);
        return;
      }
    }
    if (this.squares().every(square => square !== '')) {
      this.winner.set(null);
      this.sendResult('E');
      return;
    }
  }
  reloadActivityBoard() {
    this.notificationService.notificarNovoResultado();
  }
  resetGame() {
    this.squares.set(Array<string>(9).fill(''));
    this.winner.set(null);
    this.xIsNext.set(true);
  }
  sendResult(vencedor: string){
    this.resultadoService.postResultado(vencedor)
    .subscribe({
        next: (res) => {
          alert(`Resultado salvo!`);
          this.reloadActivityBoard();
        },
        error: (err) => {
            alert(`Erro ao salvar resultado: ${err.message}`);
        }
      }
    );
  }
}
