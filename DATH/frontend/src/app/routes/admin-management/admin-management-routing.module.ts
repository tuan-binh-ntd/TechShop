import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { LoginComponent } from '../components/login/login.component';
import { DashboardAdminComponent } from './dashboard-admin/dashboard-admin.component';
import { SpecificationCategoryListComponent } from './specification-category-list/specification-category-list.component';
import { SpecificationListComponent } from './specification-list/specification-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
 
  {
    path: 'dashboard',
    component: DashboardAdminComponent,
  },
  {
    path: 'specification',
    component: SpecificationListComponent,
    data: {
      breadcrumb: 'Home / Specification Management / Specification'
    },
  },
  {
    path: 'specification-category',
    component: SpecificationCategoryListComponent,
    data: {
      breadcrumb: 'Home / Specification Management / Specification Category'
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminManagementRoutingModule { }
