using EasyIND.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Domain.Entities
{
    public class Career : BaseEntity
    {
        public string CareerName { get; set; }


        //Relacion de Uno a Mucho

        public Area Area { get; set; }

        public int AreaId { get; set; }

        //Relacion de Uno a Uno

        public Registro Registro { get; set; }


    }
}
