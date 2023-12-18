using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ConsoleUI.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();

        }
        public bool UserRegistration(User user)
        {
            return _userService.UserRegistration(user);
        }
        public bool UserLogin(string username,string password)
        {
            return _userService.UserLogin(username, password);
        }
    }
}
