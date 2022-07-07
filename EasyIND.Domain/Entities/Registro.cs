using EasyIND.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.Entities
{
    public class Registro : BaseEntity
    {
        public string Rol { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;

        //Relacion Uno a Muchos

        public List<User> Users { get; set; }


        //Relacion de Uno a Uno

        public Career Career { get; set; }

        public int CareerId { get; set; }

    }
}
