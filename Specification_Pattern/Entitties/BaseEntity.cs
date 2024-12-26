namespace Specification_Pattern.Entitties;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime DataCreated { get; set; } = DateTime.Now;
    public DateTime? DataUpdated { get; set; }
}
