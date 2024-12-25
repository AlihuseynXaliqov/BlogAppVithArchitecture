using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interface;
using BlogApp.Model.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repository.Abstraction
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        readonly BlogDbContext blogDbContext;

        public Repository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public DbSet<TEntity> Table => blogDbContext.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public IQueryable GetAll()
        {
            return Table;
        }

        public TEntity GetById(int Id)
        {
           return Table.AsNoTracking().FirstOrDefault(x=>x.Id == Id);
        }

        public async Task<int> SaveChangeAsync()
        {
           return await blogDbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }

        public async Task<bool> IsExsist(Expression<Func<TEntity,bool>> func)
        {
            return await Table.AnyAsync(func);
        }
    }
}
