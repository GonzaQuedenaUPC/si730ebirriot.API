using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Inventory.Domain.Model.Commands;

namespace si730ebirriot.API.Inventory.Domain.Services;

/// <summary>
/// Service to handle Thing commands.
/// </summary>
public interface IThingCommandService
{
    /// <summary>
    /// Handles the creation of a new Thing.
    /// </summary>
    /// <param name="command">
    /// The command to create a new Thing.
    /// </param>
    /// <returns>
    /// The created Thing.
    /// </returns>
    public Task<Thing> Handle(CreateThingCommand command);
}