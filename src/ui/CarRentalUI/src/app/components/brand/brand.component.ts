import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { BrandService } from 'src/app/core/services/brand-service/brand.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {

  brands : any;
  constructor(private brandService:BrandService) { }

  ngOnInit(): void {
    this.brandService.getBrands().subscribe((v) => console.info(v));
  }

}
