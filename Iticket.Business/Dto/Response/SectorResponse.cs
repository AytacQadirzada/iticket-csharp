using Iticket.Core.Entities;
using Iticket.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Response
{
    public class SectorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SectorClassification SectorClassification { get; set; }
        public int RowCount { get; set; }
        public int SeatCount { get; set; }
        public int Capacity { get; set; }
    }
}
