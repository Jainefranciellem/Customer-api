import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../../customer.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
})
export class CustomerEditComponent implements OnInit {
  customer: any = {};
  isEditing = false;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadCustomer(id);
      this.isEditing = true;
    }
  }
  
  loadCustomer(id: string) {
    this.customerService.getCustomerById(id).subscribe(
      (data) => {
        this.customer = data;
        console.log('Loaded Customer:', this.customer);
      },
      (error) => {
        console.error('Erro ao carregar o cliente:', error);
      }
    );
  }
  
  saveCustomer(): void {
    if (this.customer && this.customer.id) {
      this.customerService.updateCustomer(this.customer.id, this.customer).subscribe(
        (response) => {
          console.log('Cliente atualizado com sucesso:', response);
          // Redireciona para a lista de clientes
          this.router.navigate(['/list']);
        },
        (error) => {
          console.error('Erro ao atualizar o cliente:', error);
        }
      );
    }
  }

  cancelEdit(): void {
    // Redireciona para a lista de clientes sem salvar alterações
    this.router.navigate(['/list']);
  }
}
