using Application.Features.Fuels.Commands.CreateFuel;
using Application.Features.Fuels.Commands.DeleteFuel;
using Application.Features.Fuels.Commands.UpdateFuel;
using Application.Features.Fuels.Queries.GetFuelList;
using Core.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : BaseController
{
    public FuelsController()
    {
        
    }
    // GET api/Fuels/GetList
    [HttpGet("GetList")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        var result = await Mediator.Send(new GetFuelListQuery {PageRequest = request});

        return Ok(result);
    }

    // POST api/Fuels/Add
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateFuelCommand command)
    {
        var result = await Mediator.Send(command);

        return Created("", result);
    }
    
    // PUT api/Fuels/Update
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateFuelCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
    
    // DELETE api/Fuels/Delete
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteFuelCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}