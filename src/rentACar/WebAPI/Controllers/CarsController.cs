using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Brands.Queries.GetBrandList;
using Application.Features.Cars.Queries.GetCarList;
using Core.Application.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        // GET api/Cars/GetList
        [HttpGet("GetList")]
        public async Task<IActionResult> GetAll([FromQuery]PageRequest request)
        {
            var result = await Mediator.Send(new GetCarListQuery() { PageRequest = request });

            return Ok(result);
        }
    }
}