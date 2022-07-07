using EasyIND.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string SubjectName { get; set; } = string.Empty;


        //Relacion Uno a Muchos

        public List<Qualification> Qualifications { get; set; }

        //Relacion de Uno a Mucho

        public Area Area { get; set; }

        public int AreaId { get; set; }
    }
}
