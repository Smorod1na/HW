using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreDAL.Repository.Abstraction
{
    //TEntity - це якась сутність з БД
    public interface IGenericRepository<TEntity>
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        TEntity Find(string id);
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
