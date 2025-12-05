using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities
{
    public class Seat : BaseAuditableEntity
    {
        public string RowNumber { get; set; }
        public string SeatNumber { get; set; }

        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public List<Ticket> Ticket { get; set; }
    }
}
