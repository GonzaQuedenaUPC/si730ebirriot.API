using si730ebirriot.API.Inventory.Domain.Model.Commands;
using si730ebirriot.API.Inventory.Interfaces.REST.Resources;

namespace si730ebirriot.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a CreateThingCommand from a CreateThingResource.
/// </summary>
public class CreateThingCommandFromResourceAssembler
{
    /// <summary>
    /// Create a CreateThingCommand from a CreateThingResource.
    /// </summary>
    /// <param name="resource">
    /// The resource to create a CreateThingCommand from.
    /// </param>
    /// <returns>
    /// The CreateThingCommand created from the resource.
    /// </returns>
    public static CreateThingCommand ToCommandFromResource(CreateThingResource resource)
    {
        return new CreateThingCommand(
            resource.Model,
            resource.MaximumTemperatureThreshold,
            resource.MinimumTemperatureThreshold,
            Guid.NewGuid().ToString()
        );
    }
}