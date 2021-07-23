using API_GameCatalogsDIO.InputModel;
using API_GameCatalogsDIO.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_GameCatalogsDIO.Services
{
    public interface IGameServices : IDisposable
    {
        Task<List<GameViewModel>> GetGame(int page, int quantities);
        Task<GameViewModel> GetGame(int id);
        Task<GameViewModel> SetGame(GameInputModel game);
        Task UpdateGame(int id, GameInputModel newGame);
        Task EditPriceGame(int id, double newPrice);
        Task DeleteGame(int id);
    }
}