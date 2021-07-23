using API_GameCatalogsDIO.Base;
using API_GameCatalogsDIO.Excpetions;
using API_GameCatalogsDIO.InputModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GameCatalogsDIO.Repositories
{
    public class GameRepository : IGameRepository
    {

        private static List<Game> games = new()
        {
            new Game
            {
                Id = 0,
                Name = "FIFA",
                Description = "Jogo de futebol",
                Price = 150.00,
                Producer = "EASPORTS",
                ReleaseDate = "2020"
            }
        };


        public Task SetGame(Game game)
        {
            games.Add(game);
            return Task.CompletedTask;
        }
        public Task<List<Game>> GetGame(int page, int quantities) =>
            Task.FromResult(games.Skip((page - 1) * quantities).Take(quantities).ToList());


        public Task<Game> GetGame(int id)
        {
            try
            {
                return Task.FromResult(games[id]);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                 throw new NonexistentId();
            }
        }

        public Task<List<Game>> GetGame(GameInputModel game) =>
            Task.FromResult(games.Where(gamee => gamee.Name.Equals(game.Name) && gamee.Producer.Equals(game.Producer)).ToList());


        public Task UpdateGame(Game newGame)
        {
            try
            {
                games[newGame.Id] = newGame;
                return Task.CompletedTask;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw new NonexistentId();
            }            
        }
        public Task DeleteGame(int id)
        {
            try
            {
                games.RemoveAt(id);
                return Task.CompletedTask;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw new NonexistentId();
            }
        }

        public void Dispose()
        {
            //Not Necessary
        }
    }
}