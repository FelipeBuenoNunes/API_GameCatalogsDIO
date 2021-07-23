using API_GameCatalogsDIO.Excpetions;
using API_GameCatalogsDIO.InputModel;
using API_GameCatalogsDIO.Services;
using API_GameCatalogsDIO.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace API_GameCatalogsDIO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameServices _GameService;

        public GameController(IGameServices gameService)
        {
            _GameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameViewModel>>> GetGame([FromQuery, Range(1, 100)] int page = 1, [FromQuery, Range(1, 50)] int quantities = 5)
        {
            var listGames = await _GameService.GetGame(page, quantities);

            if (listGames.Count == 0)
                return NoContent();

            return Ok(listGames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameViewModel>> GetGame([FromRoute] int id)
        {
            try
            {
                var game = await _GameService.GetGame(id);

                return Ok(game);
            }
            catch (NonexistentId)
            {
                return NotFound("Jogo inexistente");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> SetGame([FromBody] GameInputModel game)
        {
            try
            {
                var newGame = await _GameService.SetGame(game);
                return Ok(newGame);
            }
            catch (GameAlreadyRegistered) 
            {
                return UnprocessableEntity("Jogo já cadastrado");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame([FromRoute] int id, [FromBody] GameInputModel newGame)
        {
            try
            {
                await _GameService.UpdateGame(id, newGame);
                return Ok();
            }
            catch (NonexistentId)
            {
                return NotFound("Jogo inexistente");
            }

        }

        [HttpPatch("{id}/preco/{preco}")]
        public async Task<ActionResult> EditPriceGame([FromRoute] int id, [FromRoute] double preco)
        {
            try
            {
                await _GameService.EditPriceGame(id, preco);
                return Ok();
            }
            catch (NonexistentId)
            {
                return NotFound("Jogo inexistente");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame([FromRoute] int id)
        {
            try
            {
                await _GameService.DeleteGame(id);
                return Ok();
            }
            catch (NonexistentId)
            {
                return NotFound("Jogo inexistente");
            }
        }
    }
}
