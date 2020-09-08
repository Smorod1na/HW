using GameStoreBLL.Services.Abstraction;
using GameStoreDAL.Entities;
using GameStoreDAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreBLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IGenericRepository<Developer> _repoDev;
        private readonly IGenericRepository<Game> _repoGame;
        public DeveloperService(IGenericRepository<Game> repoGame,IGenericRepository<Developer> repoDev)
        {
            _repoDev = repoDev;
            _repoGame = repoGame;
        }

        public void AddDeveloper(Developer dev)
        {
            _repoDev.Create(dev);
        }

        public void DeleteDevelopers(string name,int id)
        {
            var test = new List<Game>();
            var games = _repoGame.GetAll().ToList();
            foreach (var item in games)
            {
                if (item.Developer.Name == name)
                {
                    //games.Remove(item);
                    _repoGame.Delete(_repoGame.Find(item.Id));
                }
            }
            _repoDev.Delete(_repoDev.Find(id));
        }

        public IEnumerable<Developer> GetDevelopers()
        {
            return _repoDev.GetAll();
        }
    }
}
