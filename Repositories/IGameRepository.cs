using API_GameCatalogsDIO.Base;
using API_GameCatalogsDIO.InputModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_GameCatalogsDIO.Repositories
{
    public interface IGameRepository : IDisposable
    {
        Task SetGame(Game game);
        Task<List<Game>> GetGame(int page, int quantities);
        Task<Game> GetGame(int id);
        Task<List<Game>> GetGame(GameInputModel game);
        Task UpdateGame(Game newGame);
        Task DeleteGame(int id);
    }
}