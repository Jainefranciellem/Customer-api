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
}