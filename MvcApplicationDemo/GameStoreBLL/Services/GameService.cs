using Binbin.Linq;
using GameStoreBLL.Filters;
using GameStoreBLL.Services.Abstraction;
using GameStoreDAL.Entities;
using GameStoreDAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreBLL.Services
{
    public class GameService:IGameService
    {
        private readonly IGenericRepository<Game> repo;
        private readonly IGenericRepository<Genre> repoGenre;
        private readonly IGenericRepository<Developer> repoDev;

        public GameService(IGenericRepository<Game> _repo, IGenericRepository<Genre> _repoGenre, IGenericRepository<Developer> _repoDev)
        {
            repo = _repo;
            repoDev = _repoDev;
            repoGenre = _repoGenre;
        }

        public void AddDeveloper(Developer dev)
        {
            repoDev.Create(dev);
        }

        public void AddGame(Game game)
        {
            var entity = game;

            var genres = repoGenre.GetAll().FirstOrDefault(x => x.Name == game.Genre.Name);
            entity.Genre = genres;


            var dev = repoDev.GetAll().FirstOrDefault(x => x.Name == game.Developer.Name);
            entity.Developer = dev;

            repo.Create(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(repo.Find(id));
        }

        public void DeleteDeveloper(string name,int id)
        {
            var test = new List<Game>();
            var games = repo.GetAll().ToList();
            foreach(var item in games)
            {
                if(item.Developer.Name==name)
                {
                    //games.Remove(item);
                    repo.Delete(repo.Find(item.Id));
                }
            }
            repoDev.Delete(repoDev.Find(name));
        }

        public ICollection<Game> FilterGames(List<GamesFilter> filters)
        {
            if (filters.Count != 0)
            {
                var predicares = new List<Expression<Func<Game, bool>>>();
                foreach(var type in filters.GroupBy(x=>x.Type))
                {
                    var predicates = PredicateBuilder.Create(type.First().Predicat);
                    for (int i = 1; i < type.Count(); i++)
                    {
                        predicates = predicates.Or(type.ToList()[i].Predicat);
                    }
                    predicares.Add(predicates);
                }
                var res = PredicateBuilder.Create(predicares[0]);
                    for(int i=1;i< predicares.Count();i++)
                {
                    res = res.And(predicares[i]);
                }
                var games = repo.Filter(res);

                return games.ToList();
            }
            else return repo.GetAll().ToList();
        }

        public ICollection<string> GetAllDevelopers()
        {
            return repoDev.GetAll().Select(x => x.Name).ToList();
        }

        public ICollection<Game> GetAllGames()
        {
            return repo.GetAll().ToList();
        }

        public ICollection<string> GetAllGenres()
        {
            return repoGenre.GetAll().Select(x => x.Name).ToList();
        }

        public Game GetGame(int id)
        {
            return repo.Find(id);
        }

        public void Update(Game game)
        {
            var found = repo.Find(game.Id);
            found = game;
            
            repo.Update(found);
        }

       
    }
}
