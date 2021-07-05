using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.API.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task Crear(T entity);
        Task<T> TraerUno(String id);
        Task<List<T>> TraerTodos();
    }
}
