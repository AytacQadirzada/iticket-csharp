using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities;

public class Hall : BaseAuditableEntity
{
    public string Name { get; set; }
    public ICollection<Sector> Sectors { get; set; } = new List<Sector>();
    public int VenueId { get; set; }
    public Venue Venues { get; set; }
}
