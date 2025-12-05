using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request
{
    public class TicketRequestDto
    {
        public string UserId { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public int SeatId { get; set; }
    }
}
