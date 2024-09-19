import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from '../../customer.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Customer } from '../../Customer';

@Component({
  selector: 'app-customer-create',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './customer-create.component.html',
})
export class CustomerCreateComponent {

  customer: Customer = {
    firstName: '',
    lastName: '',
    email: '',
    phone: ''
  };

  constructor(private customerService: CustomerService, private router: Router) {}

  ngOnInit(): void {
  }
  createCustomer(): void {
    this.customerService.createCustomer(this.customer).subscribe(
      data =>{
        console.log(data);
        this.goToCustomerList();
      },
      error => console.log(error));
  }

  goToCustomerList(){
    this.router.navigate(['/customer-list']);
  }


  onSubmit(){
    console.log(this.customer);
    this.createCustomer();
  }
}
