using Specification_Pattern.Entitties;
using System.Linq.Expressions;

namespace Specification_Pattern.Specifications;

public abstract class Specification<TEntity> where TEntity : BaseEntity
{
    public  Expression<Func<TEntity, bool>>? Criteria {  get; }

    public List<Expression<Func<TEntity, object>>>? Includes { get; } = new List<Expression<Func<TEntity, object>>>();
    public Expression<Func<TEntity,object>>? OrderBy { get; private set; } 
    public Expression<Func<TEntity,object>>? OrderByDesc { get; private set; } 
    public Specification()
	{

	}

	public Specification(Expression<Func<TEntity,bool>> criteria)
	{
        Criteria = criteria; // g =>g.Genre.Name == "Rpg"
    }

    protected void AddIncludes(Expression<Func<TEntity,object>> include)
    {
        Includes?.Add(include); //g =>g.Genre , g =>g.DLCs
    }

    protected void AddOrderBy(Expression<Func<TEntity,object>> orderBy)
    {
       OrderBy = orderBy; //g =>g.Name
    }
    protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDesc)
    {
        OrderBy = orderByDesc; //g =>g.Name
    }
}
