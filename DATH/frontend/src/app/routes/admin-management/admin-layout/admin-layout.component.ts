import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.less']
})
export class AdminLayoutComponent implements OnInit {
  isCollapsed = false;
  constructor() { }

  ngOnInit(): void {
  } 

  onCollapse(ev: any){
    this.isCollapsed = ev;
  }

}