using API_GameCatalogsDIO.Base;
using API_GameCatalogsDIO.Excpetions;
using API_GameCatalogsDIO.InputModel;
using API_GameCatalogsDIO.Repositories;
using API_GameCatalogsDIO.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GameCatalogsDIO.Services
{
    public class GameServices : IGameServices
    {
        private readonly IGameRepository _gameRepository;
        private static int Id = 1;

        public GameServices(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameViewModel>> GetGame(int page, int quantities)
        {
            var result = await _gameRepository.GetGame(page, quantities);


            return result.Select(game => new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                Producer = game.Producer,
                ReleaseDate = game.ReleaseDate
            }
                ).ToList();

        }

        public async Task<GameViewModel> GetGame(int id)
        {
            var result = await _gameRepository.GetGame(id);

            if (result == null)
                throw new NonexistentId();

            return new GameViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                Producer = result.Producer,
                ReleaseDate = result.ReleaseDate
            };
        }

        public async Task<GameViewModel> SetGame(GameInputModel game)
        {
            var confirmExistence = await _gameRepository.GetGame(game);
            if (confirmExistence.Count > 0)
                throw new GameAlreadyRegistered();

            var newGame = new Game
            {
                Id = Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                Producer = game.Producer,
                ReleaseDate = game.ReleaseDate
            };
            Id++;

            await _gameRepository.SetGame(newGame);

            return new GameViewModel
            {
                Id = newGame.Id,
                Name = newGame.Name,
                Description = newGame.Description,
                Price = newGame.Price,
                Producer = newGame.Producer,
                ReleaseDate = newGame.ReleaseDate
            };
        }

        public async Task EditPriceGame(int id, double newPrice)
        {
            var newGame = await _gameRepository.GetGame(id);

            if (newGame == null)
                throw new NonexistentId();

            newGame.Price = newPrice;

            await _gameRepository.UpdateGame(newGame);
        }

        public async Task UpdateGame(int id, GameInputModel newGame)
        {
            var game = await _gameRepository.GetGame(id);

            if (game == null)
                throw new UnregisteredGame();

            game.Name = newGame.Name;
            game.Price = newGame.Price;
            game.Producer = newGame.Producer;
            game.ReleaseDate = newGame.ReleaseDate;
            game.Description = newGame.Description;

            await _gameRepository.UpdateGame(game);
        }

        public async Task DeleteGame(int id)
        {
            var gameDelete = await _gameRepository.GetGame(id);

            if (gameDelete == null)
                throw new NonexistentId();

            await _gameRepository.DeleteGame(id);
        }

        public void Dispose()
        {
            _gameRepository.Dispose();
        }
    }
}