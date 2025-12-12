using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Response
{
    public class VenuesResponse
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string MapLat { get; set; }
        public string MapLng { get; set; }
        public ICollection<ProductEventResponse> ProductEvents { get; set; }
    }
}
