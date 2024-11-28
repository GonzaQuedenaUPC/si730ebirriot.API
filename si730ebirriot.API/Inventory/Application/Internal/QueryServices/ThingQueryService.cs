using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Inventory.Domain.Model.Queries;
using si730ebirriot.API.Inventory.Domain.Repositories;
using si730ebirriot.API.Inventory.Domain.Services;

namespace si730ebirriot.API.Inventory.Application.Internal.QueryServices;

/// <summary>
/// Service to query Things.
/// </summary>
/// <param name="thingRepository">
/// The repository for Things.
/// </param>
public class ThingQueryService(IThingRepository thingRepository) : IThingQueryService
{
    /// <summary>
    /// The repository for Things.
    /// </summary>
    /// <param name="query">
    /// The query to get a Thing by its ID.
    /// </param>
    /// <returns>
    /// The Thing with the given ID.
    /// </returns>
    public async Task<Thing?> Handle(GetThingByIdQuery query)
    {
        return await thingRepository.FindByIdAsync(query.Id);
    }
}