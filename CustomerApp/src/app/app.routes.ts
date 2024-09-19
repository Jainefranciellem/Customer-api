import { Routes } from '@angular/router';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { CustomerEditComponent } from './components/customer-edit/customer-edit.component';

export const routes: Routes = [
    { path: 'list', component: CustomerListComponent},
    { path: 'edit/:id', component: CustomerEditComponent },
];
