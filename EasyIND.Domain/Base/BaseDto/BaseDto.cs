using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyIND.Domain.BaseModel.BaseDto
{
    public class BaseDto : IBaseDto
    {
        public virtual int? Id { get; set; }
        [JsonIgnore]
        public virtual bool Deleted { get; set; }
    }
}
