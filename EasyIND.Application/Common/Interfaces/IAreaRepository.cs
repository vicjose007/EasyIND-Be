using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IAreaRepository
    {
        List<Area> GetAllAreas();

        Area CreateArea(Area area);

        Area DeleteArea(Area areaId);


    }
}
