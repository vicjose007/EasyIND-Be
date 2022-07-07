using EasyIND.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Dtos
{
    public class CareerDto : BaseEntityDto
    {
        public string CareerName { get; set; }

        public int AreaId { get; set; }
    }
}
