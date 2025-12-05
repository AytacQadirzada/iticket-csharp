using Iticket.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Iticket.Core.Entities;

public class Category : BaseAuditableEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Slug { get; set; }

    public long? Ordering { get; set; }
    public ICollection<Product> Products { get; set; }
}
