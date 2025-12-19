using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Response
{
    public class HallResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SectorResponse> Sectors { get; set; }
    }
}
