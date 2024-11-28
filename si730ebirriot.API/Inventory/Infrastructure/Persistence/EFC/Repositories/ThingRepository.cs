using Microsoft.EntityFrameworkCore;
using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Inventory.Domain.Model.ValueObjects;
using si730ebirriot.API.Inventory.Domain.Repositories;
using si730ebirriot.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebirriot.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebirriot.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository for Things. 
/// </summary>
/// <param name="context">
/// The database context.
/// </param>
public class ThingRepository(AppDbContext context) : BaseRepository<Thing>(context), IThingRepository
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
    public async Task<bool> ExistsBySerialNumberAsync(SerialNumber serialNumber)
    {
        return await Context.Set<Thing>().AnyAsync(t => t.SerialNumber.Identifier == serialNumber.Identifier);
    }

    /// <summary>
    /// Obtains a Thing by its id number.
    /// </summary>
    /// <param name="id">
    /// The id of the Thing.
    /// </param>
    /// <returns>
    /// The Thing with the given id.
    /// </returns>
    public async Task<Thing?> FindByThingIdAsync(int id)
    {
        return await Context.Set<Thing>().FirstOrDefaultAsync(t => t.Id == id);
    }
}