using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User CreateUser(User user);

        User DeleteUser(User user);


    }
}
