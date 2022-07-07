using EasyIND.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string ProfessorName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        //Relacion Uno a Muchos

        public List<Qualification> Qualifications { get; set; }
    }
}
