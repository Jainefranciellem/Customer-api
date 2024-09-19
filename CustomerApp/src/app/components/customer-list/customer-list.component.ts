import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../customer.service';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [NgFor],
  templateUrl: './customer-list.component.html',
})
export class CustomerListComponent implements OnInit {
  customers: any[] = [];

  constructor(private customerService: CustomerService, private router: Router) {}
  
  ngOnInit(): void {
    this.loadCustomers();
  }
  
  loadCustomers(): void {
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = customers;
    });
  }
  
  editCustomer(customer: any) {
    this.router.navigate(['/customer-edit', customer.id]);
  }

  deleteCustomer(id: number) {
    if (confirm('Você tem certeza que deseja excluir este cliente?')) {
      this.customerService.deleteCustomer(id).subscribe(() => {
        this.customers = this.customers.filter((c) => c.id !== id);
      });
    }
  }
}
