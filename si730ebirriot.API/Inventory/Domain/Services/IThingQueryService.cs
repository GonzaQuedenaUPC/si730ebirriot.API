using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Inventory.Domain.Model.Queries;

namespace si730ebirriot.API.Inventory.Domain.Services;

/// <summary>
/// Service to query Things.
/// </summary>
public interface IThingQueryService
{
    /// <summary>
    /// Get a Thing by its ID.
    /// </summary>
    /// <param name="query">
    /// The query to get a Thing by its ID.
    /// </param>
    /// <returns>
    /// The Thing with the given ID.
    /// </returns>
    Task<Thing?> Handle(GetThingByIdQuery query);
}