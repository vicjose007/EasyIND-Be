using EasyIND.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.Entities
{
    public class Qualification : BaseEntity
    {
        public string QualificationResult { get; set; }

        //Relacion de Uno a Mucho

        public User User { get; set; }

        public int UserId { get; set; }


        //Relacion de Uno a Mucho

        public Professor Professor { get; set; }

        public int ProfessorId { get; set; }


        //Relacion de Uno a Mucho

        public Subject Subject { get; set; }

        public int SubjectId { get; set; }
    }
}
