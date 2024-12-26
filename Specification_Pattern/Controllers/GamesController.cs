using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Specification_Pattern.Repositories;
using Specification_Pattern.Specifications;

namespace Specification_Pattern.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GamesController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    //[HttpGet]
    //public IActionResult GetGames()
    //{
    //    return Ok(_gameRepository.GetGames());
    //}


    [HttpGet]
    public IActionResult GetRpgGames()
    {

        var specification = new RpgGameSpecification();

        return Ok(_gameRepository.GetGames(specification));
    }
}
