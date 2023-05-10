import { DecimalPipe } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NzMark, NzMarks } from 'ng-zorro-antd/slider';
import { forkJoin, switchMap } from 'rxjs';
import { PaginationInput } from 'src/app/models/pagination-input';
import { ProductCategory } from 'src/app/models/product-category.model';
import { Product } from 'src/app/models/product.model';
import { Specification } from 'src/app/models/specification.model';
import { ProductCategoryService } from 'src/app/services/product-category.service';
import { ProductService } from 'src/app/services/product.service';
import { checkResponseStatus } from 'src/app/shared/helper';

@Component({
  selector: 'app-view-product-list',
  templateUrl: './view-product-list.component.html',
  styleUrls: ['./view-product-list.component.less']
})
export class ViewProductListComponent {
  constructor(private route: ActivatedRoute,
    private productService: ProductService,
    private productCategoryService: ProductCategoryService,
   ) { }
  paginationParam: PaginationInput = { pageNum: 1, pageSize: 10, totalPage: 0, totalCount: 0 };
  
  type: string | null = '';
  categoryId: number = 0;

  listCategory: ProductCategory[] = [];
  listSpecification: Specification[] = [];
  listOfData: Product[] = [];
  listColor: Specification[] = [];
  listCapacity: Specification[] = [];
  marks: NzMarks = {
    0: "10000000",
   100:"50000000",
  };
  formatter(value: any) {
    return value.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
  }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap(async params => {
        await this.fetchProductCategories();
        this.listSpecification = [];
        this.listOfData = [];
        this.listColor = [];
        this.listCapacity = [];
        this.type = params.get('type')?.toUpperCase()!;
        this.categoryId = this.listCategory.find(item => item.name?.toLowerCase() === this.type?.toLowerCase())?.id!;
        if (this.categoryId) {
          await this.fetchProductCategoriesSpecification();
          return this.fetchData();
        }
        return null;
      })
    ).subscribe();
  }

  async fetchProductCategories() {
    await this.productCategoryService.getAll().toPromise().then((res: any) => {
      if (checkResponseStatus(res)) {
        this.listCategory = res?.data;
      }
    })
  }

  async fetchProductCategoriesSpecification() {
    await this.productCategoryService.getAllBySpecificationById(this.categoryId).subscribe((res: any) => {
      if (checkResponseStatus(res)) {
        this.listSpecification = res?.data;
        this.listColor = res.data.find((item: any) => item.code === 'color')?.specifications;
        this.listCapacity = res.data.find((item: any) => item.code === 'capacity')?.specifications;

      }
    })
  }

  fetchData() {
    this.productService.getAllByCategory(this.categoryId, this.paginationParam.pageNum, this.paginationParam.pageSize).subscribe(res => {
      if (checkResponseStatus(res)) {
        this.listOfData = res.data.content;
      }
    })
  }

}
