using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyIND.Domain.BaseModel.BaseDto;

namespace EasyIND.Domain.BaseModel.BaseEntityDto
{
    public interface IBaseEntityDto : IBaseDto
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
