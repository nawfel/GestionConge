using Application.contracts.persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionConge.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Domain.Common;

namespace GestionConge.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext.DatabaseContext context;

        public GenericRepository(DatabaseContext.DatabaseContext context)
        {
            this.context = context;
        }


        public async Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return
                await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q=>q.Id==id);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            context.Entry(entity).State=EntityState.Modified;
            await context.SaveChangesAsync();
        }

        async Task IGenericRepository<T>.CreateAsync(T entity)
        {
            await context.AddAsync(entity);
            context.SaveChanges();

        }
    }
}
