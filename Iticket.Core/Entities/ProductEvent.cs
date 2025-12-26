using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities
{
    public class ProductEvent : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string EventName { get; set; }
        public double MinPrice { get; set; }
        public DateTime? EventDate { get; set; }
        //public int HallId { get; set; }
        //public Hall Hall { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
