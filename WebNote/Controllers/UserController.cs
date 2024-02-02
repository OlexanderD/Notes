using AutoMapper;
using FluentValidation;
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

        private readonly IValidator<UserViewModel> _validator;
        public UserController(IUserService userService,IMapper mapper, ILogger<UserController> logger,IValidator<UserViewModel> validator)
        {
            _userService = userService;

            _mapper = mapper;

            _logger = logger;

            _validator = validator;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            _logger.LogInformation("All Users");
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public IActionResult UserRegistration(UserViewModel userViewModel)
        {
            var validationResult = _validator.Validate(userViewModel);


            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }
            _logger.LogInformation($"Registration completed");
            _userService.UserRegistration(_mapper.Map<User>(userViewModel));

            return Ok("Registration completed");
            
        }

        [HttpGet("{id}")]
        public IActionResult UserLogin([FromQuery] UserViewModel  userViewModel)
        {
            var validationResult = _validator.Validate(userViewModel);


            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }
            _logger.LogInformation("Login completed");
            var user = _userService.UserLogin(userViewModel.UserName, userViewModel.Password);

            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok("Login completed");
        }

    }
}
