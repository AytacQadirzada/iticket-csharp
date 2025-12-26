using Iticket.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Iticket.Core.Entities;

public class Venue : BaseAuditableEntity
{
    public string Address { get; set; }
    public string Mobile { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string MapLat { get; set; }
    public string MapLng { get; set; }
    public ICollection<Hall> Halls { get; set; } = new List<Hall>();
}
