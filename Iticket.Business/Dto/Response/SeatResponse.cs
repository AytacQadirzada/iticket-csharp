using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Response
{
    public class SeatResponse
    {
        public int Id { get; set; }
        public string RowNumber { get; set; }
        public string SeatNumber { get; set; }
        public Sector Sector { get; set; }
        public List<Ticket> Ticket { get; set; }
    }
}
