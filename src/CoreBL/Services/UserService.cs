using AutoMapper;
using CoreBL.Interfaces;
using CoreBL.Models;
using CoreDAL.Entities;
using CoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            if (!char.IsUpper(user.FirstName[0]) || !char.IsUpper(user.LastName[0]))
            {
                throw new ArgumentException("First and Last name should start with capital letter!");
            }

            var createdUser = await _userRepository.Add(_mapper.Map<UserDto>(user));
            return _mapper.Map<User>(createdUser);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var dbItems = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<User>>(dbItems);
        }

        public async Task<User> GetUserById(Guid id)
        {
            var dbUser = await _userRepository.GetById(id);
            return _mapper.Map<User>(dbUser);
        }

        public async Task<User> UpdateUserById(Guid id, User user)
        {
            var dbUser = await _userRepository.UpdateById(id, _mapper.Map<UserDto>(user));
            return _mapper.Map<User>(dbUser);
        }

        public async Task<int> RemoveUserById(Guid id)
        {
            return await _userRepository.RemoveById(id);
        }
    }
}
