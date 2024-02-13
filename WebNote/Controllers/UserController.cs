using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;
        public UserController(IUserService userService,IMapper mapper, ILogger<UserController> logger,IValidator<UserViewModel> validator,
               UserManager <User> userManager,SignInManager<User> signInManager)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            _logger.LogInformation("All Users");
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserViewModel userViewModel)
        {
            var validationResult = _validator.Validate(userViewModel);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { Property = e.PropertyName, e.ErrorMessage });

                return BadRequest(new { Errors = errors });
            }

            var user = _mapper.Map<User>(userViewModel);
            var result = await _userManager.CreateAsync(user, userViewModel.Password);

            if (!result.Succeeded)
            {
                _logger.LogInformation($"Registration failed");

                return BadRequest("Invalid username or password");
            }

            await _signInManager.SignInAsync(user, false);

            return Ok("Registration completed");
            
        }

        [HttpGet("login/")]
        public async Task<IActionResult> UserLogin([FromQuery] UserViewModel  userViewModel)
        {
            var validationResult = _validator.Validate(userViewModel);


            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { Property = e.PropertyName, e.ErrorMessage });

                return BadRequest(new { Errors = errors });
            }

            var result = await _signInManager.PasswordSignInAsync(userViewModel.UserName, userViewModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                _logger.LogInformation("Login failed");

                return BadRequest("Invalid username or password");                
            }

            return Ok("Login completed");
        }

    }
}
