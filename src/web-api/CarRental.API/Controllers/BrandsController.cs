using System.Collections.Generic;
using System.Net;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Brand>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetBrands()
        {
            var brands = _brandService.GetAll(null);

            if (!brands.IsSuccess)
            {
                return BadRequest(error: brands.Message);
            }

            return Ok(brands.Data);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IDataResult<Brand>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IDataResult<Brand>), (int)HttpStatusCode.BadRequest)]
        public ActionResult CreateBrand([FromBody] Brand brand)
        {
            var result = _brandService.Add(brand);

            if (!result.IsSuccess)
            {
                return BadRequest(error: result.Message);
            }

            return Ok(result);

        }

    }
}
