using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request
{
    public class FilterRequest
    {
        public int? VenuesId { get; set; }
        public DateTime? ProductEventDate { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
