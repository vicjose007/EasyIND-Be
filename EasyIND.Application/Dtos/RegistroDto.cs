using EasyIND.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Dtos
{
    public class RegistroDto : BaseEntityDto
    {
        public string Rol { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;

        public int CareerId { get; set; }
    }
}
