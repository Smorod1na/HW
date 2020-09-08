using GameStoreBLL.Filters;
using GameStoreBLL.Services.Abstraction;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreBLL.Services
{
    public class TestService : IGameService
    {
        public void AddDeveloper(Developer dev)
        {
            throw new NotImplementedException();
        }

        public void AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeveloper(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeveloper(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeveloper(string name, int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Game> FilterGames(List<GamesFilter> filters)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Game> GetAllGames()
        {
            return new List<Game>()
            {
                new Game{Name="1111"},
                                new Game{Name="2222"},
                                                new Game{Name="3333"},

            };
        }

        public ICollection<string> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public Game GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
