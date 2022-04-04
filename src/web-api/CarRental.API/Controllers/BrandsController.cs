using AutoMapper;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using CarRental.Entities.Dtos.Brand;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;
        public BrandsController(IBrandService brandService, ICarService carService)
        {
            _brandService = brandService;
        }

        [HttpGet("", Name = "GetBrands")]
        [ProducesResponseType(typeof(IDataResult<List<BrandGetDto>>), (int)HttpStatusCode.OK)]
        public IActionResult GetBrands()
        {
            IDataResult<List<BrandGetDto>> brands = _brandService.GetAll(null);
            return Ok(brands);
        }

        [HttpGet("{id}", Name = "GetBrand")]
        [ProducesResponseType(typeof(IDataResult<BrandGetDto>), (int)HttpStatusCode.OK)]
        public ActionResult GetBrand(int id)
        {
            IDataResult<BrandGetDto> brand = _brandService.Get(I => I.Id == id);
            
            return Ok(brand);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.BadRequest)]
        public ActionResult CreateBrand([FromBody] BrandInsertDto brand)
        {
            IResult result = _brandService.Add(brand);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPut]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.BadRequest)]
        public ActionResult UpdateBrand([FromBody] BrandUpdateDto brand)
        {
            IResult result = _brandService.Update(brand);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpDelete("{id}", Name = "DeleteBrand")]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.BadRequest)]
        public ActionResult DeleteBrand(int id)
        {
            IResult result = _brandService.Delete(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
