namespace si730ebirriot.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to create a new Thing.
/// </summary>
/// <param name="Model">
/// The model of the Thing.
/// </param>
/// <param name="MaximumTemperatureThreshold">
/// The maximum temperature threshold of the Thing.
/// </param>
/// <param name="MinimumTemperatureThreshold">
/// The minimum temperature threshold of the Thing.
/// </param>
public record CreateThingCommand(string Model, 
    decimal MaximumTemperatureThreshold, decimal MinimumTemperatureThreshold);