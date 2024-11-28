using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Inventory.Interfaces.REST.Resources;

namespace si730ebirriot.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler to convert a Thing entity to a Thing resource. 
/// </summary>
public class ThingResourceFromEntityAssembler
{
    /// <summary>
    /// Convert a Thing entity to a Thing resource.
    /// </summary>
    /// <param name="entity">
    /// The Thing entity to convert.
    /// </param>
    /// <returns>
    /// The Thing resource.
    /// </returns>
    public static ThingResource ToResourceFromEntity(Thing entity)
    {
        return new ThingResource(
            entity.Id,
            entity.SerialNumber.Identifier.ToString(),
            entity.Model,
            entity.OperationModeString,
            entity.MaximumTemperatureThreshold,
            entity.MinimumTemperatureThreshold
        );
    }
}