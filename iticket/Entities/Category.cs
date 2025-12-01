using iticket.Entities.Base;

namespace iticket.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
}
