using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using templateAPI.Domain.Interfaces;
using templateAPI.Domain.Models;

namespace templateAPI.Infra.Data.Repositories {
    public class RepositoryBase<TModel> : IRepository<TModel> where TModel : EntityBase {
        private readonly DbContext _context;

        public RepositoryBase (DbContext context) {
            this._context = context;
        }

        public async Task<TModel> CreateAsync (TModel obj) {
            try {
                await this._context.AddAsync (obj);
                await this._context.SaveChangesAsync ();
                return obj;
            } catch (System.Exception ex) {
                throw ex;
            }
        }

        public async Task<TModel> DeleteAsync (Guid id) {
            try {
                var obj = await this._context.Set<TModel> ().FindAsync (id);
                this._context.Set<TModel> ().Remove (obj);
                await this._context.SaveChangesAsync ();
                return obj;
            } catch (System.Exception ex) {
                throw ex;
            }
        }

        public IQueryable<TModel> Read () {
            try
            {
                return _context.Set<TModel>().AsNoTracking();
            }
            catch (System.Exception ex)
            {                
                throw ex;
            }
        }

        public async Task<TModel> UpdateAsync (Guid id, TModel obj) {
            try {
                var model = await this._context.Set<TModel> ().FindAsync (id);
                if (model != null && model?.Id == obj.Id) {
                    this._context.Set<TModel> ().Update (obj);
                    await this._context.SaveChangesAsync ();
                }
                return obj;
            } catch (System.Exception ex) {
                throw ex;
            }
        }
    }
}