using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request
{
    public class AddItem
    {
        [Required]
        public string UserId { get; set; }
        public string?  TicketId { get; set; }
        public int Quantity { get; set; }
        public int SectorId { get; set; }
        [Required]
        public int ProductEventId { get; set; }

    }
}
