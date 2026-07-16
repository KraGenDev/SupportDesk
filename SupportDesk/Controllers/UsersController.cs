using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportDesk.Core.Domain.Enums;
using SupportDesk.Core.Domain.Interfaces.Services;
using SupportDesk.Core.Domain.Models;

namespace SupportDesk.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<User> _userValidator;

        public UsersController(IUserService userService, IValidator<User> userValidator) 
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpPost("/registry")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> RegistryNewUserAsync([FromBody] User user)
        {
            var validationResult = await _userValidator.ValidateAsync(user);

            if (validationResult != null && !validationResult.IsValid)
                return ValidationProblem();

            await _userService.RegisterNewUserAsync(user);

            return Created();
        }

        [HttpPost("/add")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] User newUser,User creator)
        {
            if (newUser == null || creator == null)
                return BadRequest();

            var validationResult = await _userValidator.ValidateAsync(newUser);

            if(validationResult == null || !validationResult.IsValid)
                return ValidationProblem();

            await _userService.AddUserAsync(newUser, creator);

            return Created();
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(UserRole.Agent)},{nameof(UserRole.Admin)}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpPost("/delete/{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            if(id ==  Guid.Empty)
                return BadRequest(id);

            await _userService.DeleteUserAsync(id);
            return Ok();
        }


        [HttpPut("/update/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateUserAsync(User updatedUser,User initiator)
        {
            if(updatedUser == null || initiator == null)
                return BadRequest();

            if(initiator.Role == UserRole.Costumer && updatedUser.Id != initiator.Id)
                return BadRequest();

            if (updatedUser.Role == UserRole.Admin && initiator.Role != UserRole.Admin)
                return BadRequest();

            var validationResult = await _userValidator.ValidateAsync(updatedUser);

            if(validationResult == null || !validationResult.IsValid)
                return ValidationProblem();

            await _userService.UpdateUserAsync(updatedUser);

            return Ok();
        }
    }
}
