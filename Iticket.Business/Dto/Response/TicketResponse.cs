using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Response
{
    public class TicketResponse
    {
        public int Id { get; set; }
        public User User { get; set; }
        public double Price { get; set; }
        public string Number { get; set; }
        public Seat Seat { get; set; }
    }
}
