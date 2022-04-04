using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Brand;
using CarRental.Entities.Dtos.Car;
using CarRental.Entities.Dtos.Image;
using CarRental.Entities.Dtos.Rental;

namespace CarRental.Business.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            //Brand mapping
            CreateMap<Brand, BrandGetDto>();
            CreateMap<BrandGetDto, Brand>();

            CreateMap<Brand, BrandInsertDto>();
            CreateMap<BrandInsertDto, Brand>();

            CreateMap<Brand, BrandUpdateDto>();
            CreateMap<BrandUpdateDto, Brand>();


            //Rental mapping
            CreateMap<Rental, RentalGetDto>();
            CreateMap<RentalGetDto, Rental>();

            CreateMap<RentalInsertDto, Rental>();
            CreateMap<Rental, RentalInsertDto>();

            CreateMap<Rental, RentalUpdateDto>();
            CreateMap<RentalUpdateDto, Rental>();

            //Car mapping
            CreateMap<Car, CarGetDto>();
            CreateMap<CarGetDto, Car>();

            CreateMap<CarInsertDto, Car>();
            CreateMap<Car, CarInsertDto>();

            CreateMap<Car, CarUpdateDto>();
            CreateMap<CarUpdateDto, Car>();

            //Image Mapping

            CreateMap<Image, ImageGetDto>();
            CreateMap<ImageGetDto, Image>();

            CreateMap<ImageInsertDto, Image>();
            CreateMap<Image, CarInsertDto>();
            
            CreateMap<Image, ImageUpdateDto>();
            CreateMap<ImageUpdateDto, Image>();


        }
    }
}