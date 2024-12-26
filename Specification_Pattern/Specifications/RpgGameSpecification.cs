using Specification_Pattern.Entitties;

namespace Specification_Pattern.Specifications;

public class RpgGameSpecification:Specification<Game>
{
    public RpgGameSpecification():base(g =>g.Genre!.Name  == "RPG")
    {
        AddIncludes(g => g.Genre!);
        AddIncludes(g => g.DLCs);
        //AddOrderBy(g => g.Name);
        AddOrderByDesc(g => g.Name);
    }
}
