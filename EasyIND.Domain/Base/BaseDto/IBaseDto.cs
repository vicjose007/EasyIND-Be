using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.BaseModel.BaseDto
{
    public interface IBaseDto
    {
        int? Id { get; set; }
        bool Deleted { get; set; }
    }
}
