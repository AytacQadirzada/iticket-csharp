using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities
{
    public class Hall : BaseAuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Sector> Sectors { get; set; }
    }
}
