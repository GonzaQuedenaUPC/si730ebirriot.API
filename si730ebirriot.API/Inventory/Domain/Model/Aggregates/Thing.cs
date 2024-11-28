using si730ebirriot.API.Inventory.Domain.Model.Commands;
using si730ebirriot.API.Inventory.Domain.Model.ValueObjects;

namespace si730ebirriot.API.Inventory.Domain.Model.Aggregates;

/// <summary>
/// Aggregate root for Thing entity
/// </summary>
public partial class Thing
{
    /// <summary>
    /// Unique identifier for the Thing
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Serial number of the Thing
    /// </summary>
    public SerialNumber SerialNumber { get; set; }
    
    /// <summary>
    /// Model of the Thing
    /// </summary>
    public string Model { get; set; }
    
    /// <summary>
    /// Operation mode of the Thing
    /// </summary>
    public EOperationMode OperationMode { get; set; }
    
    /// <summary>
    /// Maximum temperature threshold of the Thing
    /// </summary>
    public decimal MaximumTemperatureThreshold { get; set; }
    
    /// <summary>
    /// Minimum temperature threshold of the Thing 
    /// </summary>
    public decimal MinimumTemperatureThreshold { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public Thing()
    {
        Model = "";
        MaximumTemperatureThreshold = 0;
        MinimumTemperatureThreshold = 0;
        SerialNumber = new SerialNumber();
        OperationMode = EOperationMode.ScheduleDriven;
    }

    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="command">
    /// Command to create a Thing
    /// </param>
    public Thing(CreateThingCommand command) : this()
    {
        this.Model = command.Model;
        this.MaximumTemperatureThreshold = command.MaximumTemperatureThreshold;
        this.MinimumTemperatureThreshold = command.MinimumTemperatureThreshold;
    }
}