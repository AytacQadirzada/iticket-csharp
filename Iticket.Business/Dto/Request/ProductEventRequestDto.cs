using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request
{
    public class ProductEventRequestDto
    {
        //public int ProductId { get; set; }
        public string EventName { get; set; }
        public double MinPrice { get; set; }
        public DateTime? EventDate { get; set; }
        public int HallId { get; set; }
    }
}
