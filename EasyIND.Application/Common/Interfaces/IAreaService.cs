using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IAreaService : IEntityCRUDService<Area, AreaDto>
    {

        List<Area> GetAllAreas();

        Area CreateArea(Area area);

        Area DeleteArea(Area area);

    }
}
