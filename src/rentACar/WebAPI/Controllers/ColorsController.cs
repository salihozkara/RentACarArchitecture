using Application.Features.Colors.Commands.CreateColor;
using Application.Features.Colors.Commands.DeleteColor;
using Application.Features.Colors.Commands.UpdateColor;
using Application.Features.Colors.Queries.GetColorList;
using Core.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    public ColorsController()
    {
        
    }
    // GET api/Colors/GetList
    [HttpGet("GetList")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        var result = await Mediator.Send(new GetColorListQuery {PageRequest = request});

        return Ok(result);
    }

    // POST api/Colors/Add
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateColorCommand command)
    {
        var result = await Mediator.Send(command);

        return Created("", result);
    }
    
    // PUT api/Colors/Update
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateColorCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
    
    // DELETE api/Colors/Delete
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteColorCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}