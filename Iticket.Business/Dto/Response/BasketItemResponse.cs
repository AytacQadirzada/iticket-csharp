using Iticket.Core.Entities;

namespace Iticket.Business.Dto.Response
{
    public class BasketItemResponse
    {
        public int Id { get; set; }
        public TicketResponse Ticket { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}