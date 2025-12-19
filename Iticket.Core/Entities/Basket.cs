using Iticket.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Core.Entities;

public class Basket : BaseAuditableEntity
{

    public ICollection<BasketItem> BasketItems { get; set; }
    public double TotalPrice { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
