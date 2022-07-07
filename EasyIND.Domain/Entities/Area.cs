using EasyIND.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.Entities
{
    public class Area : BaseEntity
    {
        public string AreaName { get; set; } = string.Empty;


        //Relacion Uno a Muchos

        public List<Subject> Subjects { get; set; }

        //Relacion Uno a Muchos

        public List<Career> Careers { get; set; }
    }
}
