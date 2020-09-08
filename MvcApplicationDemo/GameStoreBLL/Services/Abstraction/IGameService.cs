using GameStoreBLL.Filters;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreBLL.Services.Abstraction
{
    public interface IGameService
    {
        ICollection<Game> GetAllGames();
        void AddGame(Game game);
        ICollection<string> GetAllGenres();
        ICollection<string> GetAllDevelopers();
        Game GetGame(int id);
        void Update(Game game);
        void Delete(int id);
        ICollection<Game> FilterGames(List<GamesFilter> filters);
        void AddDeveloper(Developer dev);
        void DeleteDeveloper(string name,int id);
    }
}
