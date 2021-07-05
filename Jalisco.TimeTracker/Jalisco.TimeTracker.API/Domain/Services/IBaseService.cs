using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.API.Domain.Services
{
    public interface IBaseService<T>
    {
        Task Crear(T entity);
        Task<T> TreaerUno(String id);
        Task<List<T>> TraerTodos();
    }
}
