using CarRental.Business.Interfaces;
using CarRental.Entities.Concrete;
using CarRental.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public string Get()
        {
            return "CarsController";

        }
    }
}
