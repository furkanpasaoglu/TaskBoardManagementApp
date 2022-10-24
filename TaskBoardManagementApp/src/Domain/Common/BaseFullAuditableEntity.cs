namespace TaskBoardManagementApp.Domain.Common;

public class BaseFullAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? DeleterId { get; set; }
}
