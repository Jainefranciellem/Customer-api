import { Component } from '@angular/core';
import { CustomerListComponent } from '../../components/customer-list/customer-list.component';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [
    CustomerListComponent
  ],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent {

}
