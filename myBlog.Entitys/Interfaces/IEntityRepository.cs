using myBlog.Data;
using System;
using System.Linq.Expressions;

namespace myBlog.Interfaces
{
    public interface IEntityRepository<TContext, TEntity>
    where TContext : DataContext, new()
    where TEntity : class,IEntity, new()
    {
         void AddOrUpdate(TContext context, TEntity entity);
         void Delete(TContext context, Expression<Func<TEntity,bool>> filter);
         void Save(TContext context);

         
    }
}