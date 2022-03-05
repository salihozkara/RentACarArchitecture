using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Brands.Queries.GetBrandList;
using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
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
        
        // POST api/Cars/Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateCarCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        
        // PUT api/Cars/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateCarCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        
        // DELETE api/Cars/Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            var result = await Mediator.Send(new DeleteCarCommand() { Id = id });

            return Ok(result);
        }
    }
}