using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.BaseModel.Base
{
    public class Base : IBase
    {
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
