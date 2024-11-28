using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebirriot.API.Inventory.Domain.Model.Queries;
using si730ebirriot.API.Inventory.Domain.Services;
using si730ebirriot.API.Inventory.Interfaces.REST.Resources;
using si730ebirriot.API.Inventory.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace si730ebirriot.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Thing Endpoints")]
public class ThingsController(IThingQueryService thingQueryService, IThingCommandService thingCommandService)
    : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation("Get Thing by Id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Thing found", typeof(ThingResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Thing not found")]
    public async Task<IActionResult> GetThingById(int id)
    {
        var query = new GetThingByIdQuery(id);

        var thing = await thingQueryService.Handle(query);

        if (thing is null)
        {
            return NotFound(new { Title = "Not Found", message = "Thing not found" });
        }

        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return Ok(thingResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Thing")]
    [SwaggerResponse(StatusCodes.Status201Created, "Thing created", typeof(ThingResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Thing data")]
    public async Task<IActionResult> CreateThing([FromBody] CreateThingResource createThingResource)
    {
        var command = CreateThingCommandFromResourceAssembler.ToCommandFromResource(createThingResource);
        
        var thing = await thingCommandService.Handle(command);
        
        if (thing is null)
        {
            return BadRequest(new { Title = "Bad Request", message = "Invalid Thing data" });
        }

        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return CreatedAtAction(nameof(GetThingById), new { id = thing.Id }, thing);
    }
}