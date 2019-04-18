using System;
using System.Linq;
using System.Threading.Tasks;
using template.Domain.Models;

namespace template.Domain.Interfaces
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        Task<TModel> CreateAsync(TModel obj);
        Task<TModel> UpdateAsync(Guid id, TModel obj);
        Task<TModel> DeleteAsync(Guid id);
        IQueryable<TModel> Read();

    }
}