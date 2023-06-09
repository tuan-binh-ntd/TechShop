import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardAdminComponent } from './dashboard-admin/dashboard-admin.component';
import { SpecificationCategoryListComponent } from './specification-category-list/specification-category-list.component';
import { SpecificationListComponent } from './specification-list/specification-list.component';
import { ProductCategoryListComponent } from './product-category-list/product-category-list.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ShopListComponent } from './shop-list/shop-list.component';
import { ShippingListComponent } from './shipping-list/shipping-list.component';
import { PromotionListComponent } from './promotion-list/promotion-list.component';
import { RegisterEmployeeListComponent } from './register-employee-list/register-employee-list.component';
import { InstallmentListComponent } from './installment-list/installment-list.component';
import { WarehouseListComponent } from './warehouse-list/warehouse-list.component';
import { PaymentListComponent } from './payment-list/payment-list.component';
import { WarehouseDetailListComponent } from './warehouse-detail-list/warehouse-detail-list.component';
import { EmployeeChangeInfoComponent } from './employee-change-info/employee-change-info.component';
import { StoresWarehouseListComponent } from './stores-warehouse-list/stores-warehouse-list.component';
import { OrderForAdminListComponent } from './order-for-admin-list/order-for-admin-list.component';
import { OrderForShopListComponent } from './order-for-shop-list/order-for-shop-list.component';
import { OrderListComponent } from './order-list/order-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'product', pathMatch: 'full' },
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
  {
    path: 'product',
    component: ProductListComponent,
    data: {
      breadcrumb: 'Home / Product Management / Product'
    },
  },
  {
    path: 'product-category',
    component: ProductCategoryListComponent,
    data: {
      breadcrumb: 'Home / Product Management / Product Category'
    },
  },
  {
    path: 'shop',
    component: ShopListComponent,
    data: {
      breadcrumb: 'Home / Shop'
    },
  },
  {
    path: 'shipping',
    component: ShippingListComponent,
    data: {
      breadcrumb: 'Home / Shipping'
    },
  },
  {
    path: 'promotion',
    component: PromotionListComponent,
    data: {
      breadcrumb: 'Home / Promotion'
    },
  },
  {
    path: 'register-employee',
    component: RegisterEmployeeListComponent,
    data: {
      breadcrumb: 'Home / Register Employee'
    },
  },
  {
    path: 'installment',
    component: InstallmentListComponent,
    data: {
      breadcrumb: 'Home / Installment'
    },
  },
  {
    path: 'warehouse',
    component: WarehouseListComponent,
    data: {
      breadcrumb: 'Home / Warehouse Management / Warehouse'
    },
  },
  {
    path: 'payment',
    component: PaymentListComponent,
    data: {
      breadcrumb: 'Home / Payment'
    },
  },
  {
    path: 'warehouse-detail',
    component: WarehouseDetailListComponent,
    data: {
      breadcrumb: 'Home / Warehouse Management / Parent Warehouse'
    },
  },
  {
    path: 'employee-change-info',
    component: EmployeeChangeInfoComponent,
    data: {
      breadcrumb: 'Home / Change Information'
    },
  },
  {
    path: 'stores-warehouse',
    component: StoresWarehouseListComponent,
    data: {
      breadcrumb: 'Home / Stores Warehouse'
    },
  },
  {
    path: 'order',
    component: OrderListComponent,
    data: {
      breadcrumb: 'Home / Order'
    },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminManagementRoutingModule { }
