import { Routes } from '@angular/router';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { CustomerEditComponent } from './components/customer-edit/customer-edit.component';
import { CustomerCreateComponent } from './components/customer-create/customer-create.component';


export const routes: Routes = [
    { path: 'customer-list', component: CustomerListComponent },
    { path: 'customer-edit/:id', component: CustomerEditComponent },
    { path: 'customer-create', component: CustomerCreateComponent },
];
