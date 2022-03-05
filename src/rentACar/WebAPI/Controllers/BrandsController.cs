using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Queries.GetBrandList;
using Core.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    public BrandsController()
    {
        
    }
    // GET api/Brands/GetList
    [HttpGet("GetList")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        var result = await Mediator.Send(new GetBrandListQuery {PageRequest = request});

        return Ok(result);
    }

    // POST api/Brands/Add
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
    {
        var result = await Mediator.Send(command);

        return Created("", result);
    }
    
    // PUT api/Brands/Update
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
    
    // DELETE api/Brands/Delete
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}