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
    public class GenreService : IGenreService
    {

        private readonly IGenericRepository<Genre> repoGenre;
        private readonly IGenericRepository<Game> repoGame;

        public GenreService(IGenericRepository<Genre> _repoGenre,IGenericRepository<Game> _repoGame)
        {
            repoGenre = _repoGenre;
            repoGame = _repoGame;
        }
        public void AddGenre(Genre dev)
        {
            repoGenre.Create(dev);
        }

        public void DeleteGenre(string name, int id)
        {


            {
                var games = repoGame.GetAll().ToList();
                foreach (var item in games)
                {
                    if (item.Genre.Name == name)
                    {
                        //games.Remove(item);
                        repoGame.Delete(repoGame.Find(item.Id));
                    }
                }
                repoGenre.Delete(repoGenre.Find(id));
            }
        }
        public IEnumerable<Genre> GetGenres()
        {
            return repoGenre.GetAll().ToList();
        }
    }
}
