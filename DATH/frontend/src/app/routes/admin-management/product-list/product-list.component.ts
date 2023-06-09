import { Component, HostListener, ViewChild } from '@angular/core';
import { ListBaseComponent } from '../../components/list-base/list-base.component';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ProductService } from 'src/app/services/product.service';
import { ProductDrawerComponent } from './partials/product-drawer/product-drawer.component';
import { finalize } from 'rxjs';
import { checkResponseStatus } from 'src/app/shared/helper';
import { PaginationInput } from 'src/app/models/pagination-input';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.less'],
})
export class ProductListComponent extends ListBaseComponent {
  @ViewChild('drawerFormBase') override drawerFormBase!: ProductDrawerComponent;

  constructor(
    protected override msg: NzMessageService,
    private productService: ProductService
  ) {
    super(msg);
  }
  override listOfColumn: any[] = [
    {
      name: 'Name',
      width: '30%',
      sortKey: 'name',
      sortOrder: null,
      sortDirections: ['ascend', 'descend', null],
      class: 'text-left',
    },
    {
      name: 'Price',
      width: '15%',
      sortKey: 'price',
      sortOrder: null,
      sortDirections: ['ascend', 'descend', null],
      class: 'text-left',
    },
  ];

  override fetchData(): void {
    this.isLoadingTable = true;
    this.productService
      .getAll(this.paginationParam.pageNum, this.paginationParam.pageSize)
      .pipe(finalize(() => (this.isLoadingTable = false)))
      .subscribe((res) => {
        if (checkResponseStatus(res)) {
          this.listOfData = [...res.data.content];
          this.isLoadingTable = false ;
          this.paginationParam.totalCount = res.data.totalCount;
        }
      });
  }

}
