using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreBLL.Services.Abstraction
{
    public interface IGenreService
    {
        void AddGenre(Genre dev);
        IEnumerable<Genre> GetGenres();
        void DeleteGenre(string name, int id);
    }
}
