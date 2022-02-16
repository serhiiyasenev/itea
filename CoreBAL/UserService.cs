using AutoMapper;
using CoreBAL.Models;
using CoreDAL;
using CoreDAL.Entries;
using System;

namespace CoreBAL
{
    public class UserService
    {

        private UserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IMapper mapper, UserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Guid AddUser(User user)
        {

            var dbUser = _mapper.Map<UserDto>(user);
            _userRepository.Add(dbUser);
            return Guid.Empty;
        }


        public User GetUserById(Guid id)
        {
            return new User();
        }
    }
}
