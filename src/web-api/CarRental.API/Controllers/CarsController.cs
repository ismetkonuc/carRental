using System.Collections.Generic;
using System.Net;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Car;
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


        [HttpGet(template: "", Name = "GetAll")]
        [ProducesResponseType(typeof(IDataResult<List<CarGetDto>>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            return Ok(result);
        }

        [HttpGet(template: "{id}", Name = "GetById")]
        [ProducesResponseType(typeof(IDataResult<CarGetDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IDataResult<CarGetDto>), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetById(int id)
        {
            var result = _carService.Get(I => I.Id == id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost(template: "", Name = "Add")]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult Add([FromBody] CarInsertDto carAddDto)
        {
            var result = _carService.Add(carAddDto);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(template: "", Name = "Update")]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult Update([FromBody] CarUpdateDto carUpdateDto)
        {
            IResult result = _carService.Update(carUpdateDto);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete(template: "{id}", Name = "Delete")]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {
            IResult result = _carService.Delete(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
