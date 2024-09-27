using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.Data.Data.Models;
using NoteApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public bool UserRegistration(User user)
        {
            return _userRepository.UserRegistration(user);
        }
        public User? UserLogin(string username,string password)
        {
            return _userRepository.UserLogin(username,password);
        }
    }
}
