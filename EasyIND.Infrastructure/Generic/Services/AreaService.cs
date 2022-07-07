using AutoMapper;
using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Infrastructure.Generic.Services
{

    public class AreaService : EntityCRUDService<Area, AreaDto>, IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        public AreaService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow, IAreaRepository areaRepository)
            : base(mapper, uow)
        {
            _areaRepository = areaRepository;
        }
        public Area CreateArea(Area area)
        {
            _areaRepository.CreateArea(area);
            return area;
        }

        public Area DeleteArea(Area area)
        {
            _areaRepository.DeleteArea(area);
            return area;
        }
        public List<Area> GetAllAreas()
        {
            var areas = _areaRepository.GetAllAreas();

            return areas;
        }
    }
}
