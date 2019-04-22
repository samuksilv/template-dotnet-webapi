using System;
using System.Linq;
using System.Threading.Tasks;
using templateAPI.Domain.Models;

namespace templateAPI.Domain.Interfaces
{
    public interface IRepository<TModel> where TModel : EntityBase
    {
        Task<TModel> CreateAsync(TModel obj);
        Task<TModel> UpdateAsync(Guid id, TModel obj);
        Task<TModel> DeleteAsync(Guid id);
        IQueryable<TModel> Read();

    }
}