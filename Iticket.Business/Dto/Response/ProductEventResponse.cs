using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Response
{
    public class ProductEventResponse
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string EventName { get; set; }
        public double MinPrice { get; set; }
        public DateTime? EventDate { get; set; }
        public HallResponse Hall { get; set; }
    }
}
