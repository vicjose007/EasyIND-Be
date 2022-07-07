using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EasyIND.Domain.BaseModel.BaseEntity;
using EasyIND.Domain.Enum;

namespace EasyIND.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
     
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string Password { get; set; }

        public string Phone { get; set; } = string.Empty;

        public Roles roles { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        //Relacion Uno a Muchos

        public List<Qualification> Qualifications { get; set; }


        //Relacion de Uno a Mucho

        public Registro Registro { get; set; }

        public int RegistroId { get; set; }

    }
}
