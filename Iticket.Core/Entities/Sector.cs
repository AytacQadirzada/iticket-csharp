using Iticket.Core.Enums;
using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities
{
    public class Sector : BaseAuditableEntity
    {
        public string Name { get; set; }
        public int RowCount { get; set; }
        public int SeatCount { get; set; }
        public int Capacity { get; set; }
        public SectorClassification SectorClassification { get; set; }
        #region Relation
        public ICollection<Ticket> Tickets { get; set; }
        public int HallId { get; set; }
        public Hall Halls { get; set; }
        #endregion
    }
}
