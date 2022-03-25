using CarRental.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }


        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            return Ok(result);

        }

        [HttpGet("id")]
        public ActionResult Get(int id)
        {
            var result = _rentalService.Get(I => I.Id == id);

            return Ok(result);
        }
    }
}
