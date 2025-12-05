using Iticket.Core.Enums;
using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities
{
    public class Sector : BaseAuditableEntity
    {
        public string Name { get; set; }
        public SectorClassification SectorClassification { get; set; }
        #region Relation
        public ICollection<Seat> Seats { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        #endregion
    }
}
