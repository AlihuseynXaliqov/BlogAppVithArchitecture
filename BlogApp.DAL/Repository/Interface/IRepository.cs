using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Model.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repository.Interface
{
    public interface IRepository<TEntity>  where TEntity : BaseEntity, new()
    {
        DbSet<TEntity> Table { get; }
        
        TEntity GetById(int id);
        IQueryable GetAll();
        Task<TEntity> CreateAsync(TEntity entity);

        void Delete(TEntity entity);
        void Update(TEntity entity);

        Task<int> SaveChangeAsync();
        Task<bool> IsExsist(Expression<Func<TEntity, bool>> func);
    }
}
