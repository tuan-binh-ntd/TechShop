import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './routes/admin-management/admin-layout/admin-layout.component';
import { AdminLoginComponent } from './routes/admin-management/admin-login/admin-login.component';

const routes: Routes = [
  { path: 'admin', redirectTo: 'admin/login', pathMatch: 'full' },

  { path: 'admin/login', component: AdminLoginComponent },
  {
    path: 'admin-management',
    component: AdminLayoutComponent,
    loadChildren: () => import('./routes/admin-management/admin-management.module').then((m) => m.AdminManagementModule),
    // canActivate: [CheckLoadingService],
  },
  {
    path: 'user-management',
    loadChildren: () => import('./user-management/user-management.module').then((m) => m.UserManagementModule),
    // canActivate: [CheckLoadingService],
  },
  {
    path: 'exception',
    // loadChildren: './exception/exception.module#ExceptionModule',
    loadChildren: () => import('./routes/exceptions/exceptions.module').then((m) => m.ExceptionsModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
