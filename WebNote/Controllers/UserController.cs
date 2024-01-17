using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.Data.Data.Models;

namespace WebNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public bool UserRegistration(User user)
        {
            return _userService.UserRegistration(user);
        }

        [HttpGet("{id}")]
        public User? UserLogin(string username, string password)
        {
            return _userService.UserLogin(username, password);
        }
    }
}
