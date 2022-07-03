using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IUserService : IEntityCRUDService<User, UserDto>
    {
        List<User> GetAllUsers();

        User CreateUser(User user);

        User DeleteUser(User userId);


    }
}
