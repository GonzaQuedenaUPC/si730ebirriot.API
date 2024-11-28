namespace si730ebirriot.API.Inventory.Interfaces.REST.Resources;

public record ThingResource(
    int Id,
    string SerialNumber,
    string Model,
    string OperationMode,
    decimal MaximumTemperatureThreshold,
    decimal MinimumTemperatureThreshold
    );