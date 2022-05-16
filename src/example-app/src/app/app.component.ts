import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  showCidades = true;
  showPessoas = true;

  toggleCidades() { this.showCidades = !this.showCidades; }
  togglePessoas() { this.showPessoas = !this.showPessoas; }
}
