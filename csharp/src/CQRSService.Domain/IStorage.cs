using CQRSService.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSService.Client.Storage
{
    public interface IStorage<T> where T : IEntity
    {
        Task<T> GetOne(Guid id);
        Task<IEnumerable<T>> GetAll();

        Task Add(T entity);
        Task Update(T entity);
    }
}
