using Microsoft.EntityFrameworkCore;
using Specification_Pattern.Data;
using Specification_Pattern.Entitties;
using Specification_Pattern.Specifications;

namespace Specification_Pattern.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext _context;

    public GameRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    //public IEnumerable<Game> GetGames()
    //{
       
    //    return  _context.Games
    //            .Include(g =>g.Genre)
    //            .Include(g =>g.DLCs)(
    //           .ToList();
    //}

    public IEnumerable<Game> GetGames(Specification<Game> specification)
    {
        return SpecificationQueryBuilder.GetQuery(_context.Games, specification).ToList();
    }
}
