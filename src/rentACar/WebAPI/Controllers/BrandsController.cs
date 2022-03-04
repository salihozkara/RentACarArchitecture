using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Queries.GetBrandList;
using Core.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    // POST: api/Brands/Add
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody]CreateBrandCommand command)
    {
        var result = await Mediator.Send(command);

        return Created("", result);
    }
    // GET api/Brands/GetList
    [HttpGet("GetList")]
    public async Task<IActionResult> GetAll([FromQuery]PageRequest request)
    {
        var result = await Mediator.Send(new GetBrandListQuery { PageRequest = request });

        return Ok(result);
    }
}