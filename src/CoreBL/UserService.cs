using AutoMapper;
using CoreBL.Models;
using CoreDAL;
using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Credentials = CoreBL.Models.Credentials;

namespace CoreBL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private IAuthRepository _authRepository;

        public UserService(IMapper mapper, IUserRepository userRepository, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _authRepository = authRepository;
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

        public async Task<(bool status, string result)> Login(Credentials credentials)
        {
            var creds = new CoreDAL.Entities.Credentials
            {
                Login = credentials.Login,
                Password = HashPassword(credentials.Password)
            };

            var auth = await _authRepository.CreateAuthToken(creds);

            return auth;
        }


        private string HashPassword(string password)
        {
            return password;
        }
    }
}
