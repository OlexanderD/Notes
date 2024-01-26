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

        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService,IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;

            _mapper = mapper;

            _logger = logger;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            _logger.LogInformation("All Users");
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public bool UserRegistration(UserViewModel userViewModel)
        {
            _logger.LogInformation($"Registration completed");
            return _userService.UserRegistration(_mapper.Map<User>(userViewModel));
        }

        [HttpGet("{id}")]
        public User? UserLogin(string username, string password)
        {
            _logger.LogInformation("Login completed");
            return _userService.UserLogin(username, password);
        }

    }
}
