using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities;

public class Ticket : BaseAuditableEntity
{
    public string UserId { get; set; }
    public User User { get; set; }
    public double Price { get; set; }
    public int Number { get; set; }
    public int SeatId { get; set; }
    public Seat Seat { get; set; }
}
