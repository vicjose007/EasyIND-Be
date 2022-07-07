using EasyIND.Application.Common.Interfaces;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        public static List<Area> Areas = new List<Area>()
        {

        };
        private readonly EasyINDDbContext _areaDbContext;

        public AreaRepository(EasyINDDbContext areaDbContext)
        {
            _areaDbContext = areaDbContext;
        }

        public Area CreateArea(Area area)
        {
            _areaDbContext.Areas.Add(area);
            _areaDbContext.SaveChanges();
            return area;
        }

        public Area DeleteArea(Area area)
        {
            _areaDbContext.Areas.Remove(area);
            _areaDbContext.SaveChanges();

            return null;
        }

        public List<Area> GetAllAreas()
        {
            return _areaDbContext.Areas.ToList();
        }

    }
}
