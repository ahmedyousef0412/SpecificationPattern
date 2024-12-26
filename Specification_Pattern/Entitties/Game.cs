namespace Specification_Pattern.Entitties;

public class Game:BaseEntity
{
    public required string Name { get; set; }

    public Genre? Genre { get; set; }

    public List<DLC> DLCs { get; set; } = new List<DLC>();
}
