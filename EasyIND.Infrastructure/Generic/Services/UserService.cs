using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.Generic;
using EasyIND.Infrastructure.UnitOfWorks;

namespace EasyIND.Application.Services
{

    public class UserService : EntityCRUDService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow, IUserRepository userRepository)
            : base(mapper, uow)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            _userRepository.CreateUser(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
            return user;
        }
        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            return users;
        }
    }
}
