using BotWhatsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<T> GetById(long id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
