using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Services;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public static List<User> users = new List<User>()
        {

        };
        private readonly EasyINDDbContext _userDbContext;

        public UserRepository(EasyINDDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public User CreateUser(User user)
        {
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
            return user;
        }

        public User DeleteUser(User user)
        {
            _userDbContext.Users.Remove(user);
            _userDbContext.SaveChanges();

            return null;
        }

        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

    }
}
