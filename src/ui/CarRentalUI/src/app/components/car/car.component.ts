import { AfterViewInit, Component, OnInit } from '@angular/core';
import { CarGetDto } from 'src/app/core/models/CarGetDto';
import { CarType } from 'src/app/core/models/Enums/CarType';
import { GearType } from 'src/app/core/models/Enums/GearType';
import { CarService } from 'src/app/core/services/car-service/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  result : CarGetDto[] = []
  constructor(private carService: CarService) { }

  ngOnInit() {
    this.carService.carPipe.subscribe( (carType) => {
      this.getByType(carType)
    })

    this.carService.carNamePipe.subscribe( (carName) =>{
      this.getByName(carName)
    })

    // this.getCars();
  }

  getCars() {
    this.carService.getCars().subscribe(response => {
      
      if (response.isSuccess) {
        this.result = response.data;
      }
    })
  }

  getByType(type:CarType){
    this.carService.getByType(type).subscribe(response => {
      if (response.isSuccess) {
        this.result = response.data;
      }
    })
  }

  getByName(name:string){
    this.carService.getByName(name).subscribe(response => {
      if(response.isSuccess){
        this.result = response.data;
      }
    })
  }

}
