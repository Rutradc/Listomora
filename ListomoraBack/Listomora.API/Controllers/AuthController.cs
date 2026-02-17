using Listomora.API.Dto;
using Listomora.API.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Listomora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //// TODO : ajouter token de création de compte
        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] UserCreateDto dto)
        //{
        //    var isCreated = await _service.RegisterUser(dto.ToEntity());
        //    if (isCreated)
        //        return Ok();
        //    return BadRequest();
        //}
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] UserCredsDto dto)
        //{
        //    var isValid = await _service.VerifyLogin(dto.Email, dto.Password);
        //    if (isValid)
        //        return Ok();
        //    return BadRequest();
        //}
    }
}
