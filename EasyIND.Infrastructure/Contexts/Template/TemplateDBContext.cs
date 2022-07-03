using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyIND.Domain.BaseModel.BaseEntity;
using EasyIND.Domain.Entities;
using EasyIND.Domain.Models;

namespace EasyIND.Infrastructure.Contexts.EasyIND
{
    public class EasyINDDbContext : DbContext, IEasyINDDbContext
    {
        public EasyINDDbContext(DbContextOptions<EasyINDDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }


        public DbSet<T> GetDbSet<T>() where T : class, IBaseEntity => Set<T>();

        ChangeTracker IEasyINDDbContext.ChangeTracker()
        {
            return base.ChangeTracker;
        }
    }
}
