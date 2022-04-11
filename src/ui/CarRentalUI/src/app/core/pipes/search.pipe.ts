import { Pipe, PipeTransform } from '@angular/core';
import { CarService } from '../services/car-service/car.service';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

//   transform(value: any, searchValue:any): any {
//     console.log(value);
//     console.log(searchValue)
//     if (!searchValue) return value;
//     return value.filter((v:any) => v.toLowerCase().indexOf(searchValue.toLowerCase()) > -1)

//   }

constructor(private carService:CarService){}

transform(value: any, searchValue:any): any {
    
    if (!searchValue) return value;

    this.sendCarNameToPipe(searchValue)
  }

  sendCarNameToPipe(name:string){
    this.carService.iterateCarNamePipe(name)
  }

}