using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request;

public class VenueRequestDto
{
    [Required]
    public string Address { get; set; }

    [Required]
    public string Mobile { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string MapLat { get; set; }

    [Required]
    public string MapLng { get; set; }
    public ICollection<HallRequestDto> Halls { get; set; }
}
