using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities
{
    public class Hall : BaseAuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Sector> Sectors { get; set; }
        public int VenuesId { get; set; }
        public Venues Venues { get; set; }
        public ICollection<ProductEvent> ProductEvents { get; set; }
    }
}
