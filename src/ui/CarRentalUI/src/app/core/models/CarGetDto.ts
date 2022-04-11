import { CarType } from "./Enums/CarType";
import { FuelType } from "./Enums/FuelType";
import { GearType } from "./Enums/GearType";


export interface CarGetDto {
    id: number;
    name: string;
    year: number;
    fuelType: FuelType;
    gearType: GearType;
    carType: CarType;
    description: string;
    isReserved: boolean;
    price: number;
    brandId: number;
    brandName:string;
    // images: ImageGetDto[];
}