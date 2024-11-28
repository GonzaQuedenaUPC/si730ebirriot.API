using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Inventory.Domain.Model.Commands;
using si730ebirriot.API.Inventory.Domain.Model.ValueObjects;
using si730ebirriot.API.Inventory.Domain.Repositories;
using si730ebirriot.API.Inventory.Domain.Services;
using si730ebirriot.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebirriot.API.Inventory.Application.Internal.CommandServices;

/// <summary>
/// Command service for Thing commands.
/// </summary>
/// <param name="thingRepository">
/// The repository for Things.
/// </param>
/// <param name="unitOfWork">
/// The unit of work.
/// </param>
public class ThingCommandService(IThingRepository thingRepository, UnitOfWork unitOfWork)
    : IThingCommandService
{
    /// <summary>
    /// Creates a new Thing.
    /// </summary>
    /// <param name="command">
    /// The command to create a new Thing.
    /// </param>
    /// <returns>
    /// The created Thing.
    /// </returns>
    public async Task<Thing> Handle(CreateThingCommand command)
    {
        if (command.SerialNumber == string.Empty)
            throw new Exception("Serial number cannot be empty.");
        
        if (command.MaximumTemperatureThreshold < -40 || command.MaximumTemperatureThreshold > 85)
            throw new Exception("Maximum temperature threshold must be between -40.00 and 85.00.");
        
        if (command.MinimumTemperatureThreshold < 0 || command.MinimumTemperatureThreshold > 100)
            throw new Exception("Minimum temperature threshold must be between 0.00 and 100.00.");

        var exists = await thingRepository.ExistsBySerialNumberAsync(new SerialNumber(command.SerialNumber));
        
        if (exists)
            throw new Exception("Thing with the given serial number already exists.");

        var thing = new Thing(command);
        
        await thingRepository.AddAsync(thing);
        await unitOfWork.CompleteAsync();

        return thing;
    }
}