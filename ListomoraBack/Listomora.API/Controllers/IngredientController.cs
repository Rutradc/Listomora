using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Features.Ingredients.Commands;
using Listomora.Application.Features.Ingredients.Queries;
using Listomora.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Listomora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        [Authorize(Policy = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllIngredientsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPublic()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllPublicIngredientsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                string? role = User.FindFirst(ClaimTypes.Role)?.Value;
                IngredientDetailsDto ingredient;
                if (role == UserRole.ADMIN.ToString())
                    ingredient = await _mediator.Send(new GetIngredientByIdQuery(id));
                else
                {
                    string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    ingredient = await _mediator.Send(new GetIngredientByIdQuery(id, new Guid(userId)));
                }
                if (ingredient is null)
                    return NotFound();
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] IngredientCreateUpdateDto dto)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var created = await _mediator.Send(new CreateIngredientCommand(dto, new Guid(userId)));
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("{id:guid}")]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] IngredientCreateUpdateDto dto)
        {
            try
            {
                string? role = User.FindFirst(ClaimTypes.Role)?.Value;
                if (role == UserRole.ADMIN.ToString())
                {
                    await _mediator.Send(new UpdateIngredientCommand(id, dto));
                    return Ok();
                }
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _mediator.Send(new UpdateIngredientCommand(id, dto, new Guid(userId)));
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                string? role = User.FindFirst(ClaimTypes.Role)?.Value;
                if (role == UserRole.ADMIN.ToString())
                {
                    await _mediator.Send(new DeleteIngredientCommand(id));
                    return Ok();
                }
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _mediator.Send(new DeleteIngredientCommand(id, new Guid(userId)));
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("publicandmine")]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPublicAndMine()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Ok(await _mediator.Send(new GetPublicAndMyIngredientsQuery(new Guid(userId))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("mine")]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMine()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Ok(await _mediator.Send(new GetMyIngredientsQuery(new Guid(userId))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
