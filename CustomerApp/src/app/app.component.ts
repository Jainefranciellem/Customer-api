import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'Gerenciador de Clientes';

  constructor(private router: Router) {}

  CustomerCreate(): void {
    this.router.navigate(['/customer-create']);
  }
  CustomerList(): void {
    this.router.navigate(['/customer-list']);
  }
}

