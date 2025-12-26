using Iticket.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Core.Entities;

public class BasketItem : BaseAuditableEntity
{
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
    public double Price { get; set; }
    public ICollection<Basket> Baskets { get; set; }
}
