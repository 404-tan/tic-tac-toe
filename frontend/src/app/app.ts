import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Tictactoe } from "./components/tictactoe/tictactoe";
import { ActivityBoard } from "./components/activity-board/activity-board";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Tictactoe, ActivityBoard],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('frontend');
}
