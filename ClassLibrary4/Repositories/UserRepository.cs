using Microsoft.EntityFrameworkCore;
using NoteApp.Data.Data.Models;
using NoteApp.Data.Interfaces;
using NoteApp.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly TestContext _userRepository;

        public UserRepository(TestContext userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.Users.ToList();
        }
       public bool UserRegistration(User user)
        {
            var existingUser = _userRepository.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                return false;
            }

            
            _userRepository.Users.Add(user);
            _userRepository.SaveChanges();

            return true;

        }
        public User? UserLogin(string username, string password)
        {
            var user = _userRepository.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            return user;
            
        }
        
    }
}
