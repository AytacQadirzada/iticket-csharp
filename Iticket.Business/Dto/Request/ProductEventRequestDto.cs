using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request;

public class ProductEventRequestDto
{
    public string EventName { get; set; }
    public double MinPrice { get; set; }
    public DateTime? EventDate { get; set; }
    public int HallId { get; set; }
    public ICollection<SectorPriceRequestDto> SectorPrices { get; set; }
}
