using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyIND.Domain.BaseModel.BaseEntityDto
{
    public class BaseEntityDto : BaseDto.BaseDto, IBaseEntityDto
    {
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
