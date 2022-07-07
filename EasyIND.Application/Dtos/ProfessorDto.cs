using EasyIND.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Dtos
{
    public class ProfessorDto : BaseEntityDto
    {
        public string ProfessorName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
