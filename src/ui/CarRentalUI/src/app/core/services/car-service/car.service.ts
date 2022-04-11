import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarGetDto } from '../../models/CarGetDto';
import { IDataResult } from '../../models/IDataResult';
import { CarType } from '../../models/Enums/CarType'
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  carType = CarType.None
  carName = ''

  carNamePipe: BehaviorSubject<string>
  carPipe: BehaviorSubject<CarType>

  constructor(private httpClient: HttpClient) { 
    this.carPipe = new BehaviorSubject(this.carType)
    this.carNamePipe = new BehaviorSubject(this.carName)
  }
  baseUrl = "http://localhost:5000/api/"

  getCars(){
    var request_url = this.baseUrl + 'cars'
    return this.httpClient.get<any>(request_url)
  }

  getByType(type:CarType){
    var request_url = this.baseUrl + 'cars' + '/type/' + type
    return this.httpClient.get<any>(request_url)
  }

  getByName(name:string){
    var request_url = this.baseUrl + 'cars' + '/name/' + name
    return this.httpClient.get<any>(request_url)
  }

  iterateCarPipe(type:CarType){
    this.carPipe.next(type)
  }

  iterateCarNamePipe(name:string){
    this.carNamePipe.next(name)
  }


}
