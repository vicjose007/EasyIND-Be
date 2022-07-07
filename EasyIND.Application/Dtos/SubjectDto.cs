using EasyIND.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Dtos
{
    public class SubjectDto : BaseEntityDto
    {
        public string SubjectName { get; set; } = string.Empty;

        public int AreaId { get; set; }

    }
}
