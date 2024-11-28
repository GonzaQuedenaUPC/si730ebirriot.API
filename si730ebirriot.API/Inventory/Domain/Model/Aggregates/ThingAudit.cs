using System.ComponentModel.DataAnnotations.Schema;

namespace si730ebirriot.API.Inventory.Domain.Model.Aggregates;

/// <summary>
/// Represents a Thing with audit fields.
/// </summary>
public partial class Thing
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}