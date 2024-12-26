using Specification_Pattern.Entitties;
using Specification_Pattern.Specifications;

namespace Specification_Pattern.Repositories;

public interface IGameRepository
{
    IEnumerable<Game> GetGames(Specification<Game> specification);
}
