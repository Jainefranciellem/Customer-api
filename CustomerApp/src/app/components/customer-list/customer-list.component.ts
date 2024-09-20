import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../customer.service';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { Customer } from '../../Customer';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [NgFor],
  templateUrl: './customer-list.component.html',
})
export class CustomerListComponent implements OnInit {
  customers: Customer[] = [];
  paginatedCustomers: Customer[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 10;

  constructor(
    private customerService: CustomerService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.customerService.getCustomers().subscribe((customers) => {
      this.customers = customers;
      this.updatePaginatedCustomers();
    });
  }

  updatePaginatedCustomers(): void {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedCustomers = this.customers.slice(startIndex, endIndex);
  }

  changePage(page: number): void {
    this.currentPage = page;
    this.updatePaginatedCustomers();
  }

  get totalPages(): number {
    return Math.ceil(this.customers.length / this.itemsPerPage);
  }

  editCustomer(customer: any) {
    this.router.navigate(['/customer-edit', customer.id]);
  }

  deleteCustomer(id: number) {
    if (confirm('Você tem certeza que deseja excluir este cliente?')) {
      this.customerService.deleteCustomer(id).subscribe(() => {
        this.customers = this.customers.filter((c) => c.id !== id);
        this.updatePaginatedCustomers();
      });
    }
  }
}
