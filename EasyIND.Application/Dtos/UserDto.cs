﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EasyIND.Domain.BaseModel.BaseEntityDto;
using EasyIND.Domain.Entities;
using EasyIND.Domain.Enum;

namespace EasyIND.Application.Dtos
{
    public class UserDto : BaseEntityDto
    {

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string Password { get; set; }

        public string Phone { get; set; } = string.Empty;

        public Roles roles { get; set; }

        public int RegistroId { get; set; }

    }
}
