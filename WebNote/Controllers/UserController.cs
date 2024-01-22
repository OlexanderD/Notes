using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.Data.Data.Models;
using WebNote.ViewModels;

namespace WebNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;

            _mapper = mapper;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public bool UserRegistration(UserViewModel userViewModel)
        {
            return _userService.UserRegistration(_mapper.Map<User>(userViewModel));
        }

        [HttpGet("{id}")]
        public User? UserLogin(string username, string password)
        {
            return _userService.UserLogin(username, password);
        }

    }
}
