using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request
{
    public class SeatRequestDto
    {
        public string RowNumber { get; set; }
        public string SeatNumber { get; set; }
        public int SectorId { get; set; }
    }
}
