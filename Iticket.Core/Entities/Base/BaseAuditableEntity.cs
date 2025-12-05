namespace Iticket.Core.Entities.Base;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}
