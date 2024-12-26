using Microsoft.EntityFrameworkCore;
using Specification_Pattern.Entitties;

namespace Specification_Pattern.Specifications;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
                                          IQueryable<TEntity> inputQuery ,
                                          Specification<TEntity> specification)
                                          where TEntity : BaseEntity
    {
        var query = inputQuery;   //context.Game =>EntityType :Game
        if(specification.Criteria != null)
        {
            query = query.Where(specification.Criteria); // query.Where(g =>g.Genre.Name =="RPG")
        }
           

        if(specification.Includes != null)
        {
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
                         //query.Where(g =>g.Genre.Name =="RPG")
                        // .Include(g =>g.Genre)
                       //.Include(g =>g.DLCs)
        }


        if (specification.OrderBy  != null)
        {
            query = query.OrderBy(specification.OrderBy);
            //query.Where(g =>g.Genre.Name =="RPG")
            // .Include(g =>g.Genre)
            //.Include(g =>g.DLCs)
            //.OrderBy(g =>g.Name)
        }

        if (specification.OrderByDesc != null)
        {
            query = query.OrderByDescending(specification.OrderByDesc);
      
        }



        return query;
    }
}
