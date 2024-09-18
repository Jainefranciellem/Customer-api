import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../customer.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [NgFor],
  templateUrl: './customer-list.component.html',
})
export class CustomerListComponent implements OnInit {
  customers: any[] = [];

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.customerService.getCustomers().subscribe((data) => {
      this.customers = data;
    });
  }

  editCustomer(customer: any) {
    console.log('Editar cliente:', customer);
  }

  deleteCustomer(id: number) {
    if (confirm('Você tem certeza que deseja excluir este cliente?')) {
      this.customerService.deleteCustomer(id).subscribe(() => {
        
        this.customers = this.customers.filter((c) => c.id !== id);
        console.log('Cliente excluído com sucesso!');
      });
    }
  }
}