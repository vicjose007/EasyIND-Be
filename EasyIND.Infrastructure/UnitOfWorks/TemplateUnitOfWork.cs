using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyIND.Domain.BaseModel.BaseEntity;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.Repositories;

namespace EasyIND.Infrastructure.UnitOfWorks
{
    public class EasyINDUnitOfWork : IUnitOfWork<IEasyINDDbContext>
    {
        public IEasyINDDbContext context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public EasyINDUnitOfWork(IServiceProvider serviceProvider, IEasyINDDbContext context)
        {
            _serviceProvider = serviceProvider;
            this.context = context;
        }

        public async Task<int> Commit()
        {
            var result = await context.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity>(this)) as IRepository<TEntity>;
        }
    }
}
