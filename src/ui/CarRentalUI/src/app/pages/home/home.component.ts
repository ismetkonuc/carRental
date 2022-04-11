import { Component, OnInit } from '@angular/core';
import { CarType } from 'src/app/core/models/Enums/CarType';
import { CarService } from 'src/app/core/services/car-service/car.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  searchString = '';
  cars = ['Polo', 'Fabia', 'E200', 'XC90', 'Zoe', 'Clio']
  constructor(private carService:CarService) { }

  ngOnInit(): void {
  }

  sendCarTypeToPipe(type:CarType){
    this.carService.iterateCarPipe(type)
  }

  

}
