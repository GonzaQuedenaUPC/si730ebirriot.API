namespace si730ebirriot.API.Inventory.Interfaces.REST.Resources;

public record CreateThingResource(
    string Model,
    decimal MaximumTemperatureThreshold,
    decimal MinimumTemperatureThreshold
    );