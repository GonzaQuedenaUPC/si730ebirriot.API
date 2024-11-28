using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Inventory.Domain.Model.ValueObjects;
using si730ebirriot.API.Shared.Domain.Repositories;

namespace si730ebirriot.API.Inventory.Domain.Repositories;

/// <summary>
/// Repository for Things.
/// </summary>
public interface IThingRepository : IBaseRepository<Thing>
{
    /// <summary>
    /// Verifies if a Thing exists by its serial number.
    /// </summary>
    /// <param name="serialNumber">
    /// The serial number of the Thing.
    /// </param>
    /// <returns>
    /// True if the Thing exists, false otherwise.
    /// </returns>
    Task<bool> ExistsBySerialNumberAsync(SerialNumber serialNumber);
}