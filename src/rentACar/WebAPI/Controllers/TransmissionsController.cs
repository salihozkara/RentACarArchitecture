using Application.Features.Transmissions.Commands.CreateTransmission;
using Application.Features.Transmissions.Commands.DeleteTransmission;
using Application.Features.Transmissions.Commands.UpdateTransmission;
using Application.Features.Transmissions.Queries.GetTransmissionList;
using Core.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController : BaseController
{
    public TransmissionsController()
    {
        
    }
    // GET api/Transmissions/GetList
    [HttpGet("GetList")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        var result = await Mediator.Send(new GetTransmissionListQuery {PageRequest = request});

        return Ok(result);
    }

    // POST api/Transmissions/Add
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand command)
    {
        var result = await Mediator.Send(command);

        return Created("", result);
    }
    
    // PUT api/Transmissions/Update
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
    
    // DELETE api/Transmissions/Delete
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteTransmissionCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}