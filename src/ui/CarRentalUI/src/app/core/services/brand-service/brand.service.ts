import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CarGetDto } from '../../models/CarGetDto';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  constructor(private http:HttpClient) { }

  baseUrl = "http://localhost:5000/api/"
  // result : IDataResult<CarGetDto>

  getBrands(){
    var request_url = this.baseUrl + 'brands'
    return this.http.get<any>(request_url)
  }

}
