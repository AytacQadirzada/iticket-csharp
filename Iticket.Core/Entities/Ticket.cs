using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities;

public class Ticket : BaseAuditableEntity
{
    public string? UserId { get; set; }
    public User? User { get; set; }
    public double Price { get; set; }
    public string Number { get; set; }
    public string? RowNumber { get; set; }
    public string? ColumnNumber { get; set; }
    public int SectorId { get; set; }
    public Sector Sector { get; set; }
    public int ProductEventId { get; set; }
    public ProductEvent ProductEvent { get; set; }
}
