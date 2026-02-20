using Listomora.API.Handlers;
using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Features.Users.Commands;
using Listomora.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Listomora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TokenService _tokenService;

        public AuthController(IMediator mediator, TokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
        }

        // TODO : ajouter token de création de compte
        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserCreateDto dto)
        {
            if (User.Identity?.IsAuthenticated == true)
                return Forbid();
            if (!ModelState.IsValid)
                return BadRequest("Data sent is not valid.");
            if (dto is null)
                return BadRequest("No data has been sent.");
            if (dto.Password.Length > 128)
                return BadRequest("Password is too long.");
            try
            {
                await _mediator.Send(new RegisterUserCommand(dto));
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserCredsDto dto)
        {
            if (User.Identity?.IsAuthenticated == true)
                return Forbid();
            if (!ModelState.IsValid)
                return BadRequest("Data sent is not valid.");
            if (dto is null)
                return BadRequest("No data has been sent.");
            try
            {
                var user = await _mediator.Send(new LoginQuery(dto));
                
                string token = _tokenService.GenerateJwtToken(user);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
