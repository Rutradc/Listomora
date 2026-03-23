using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Features.ShoppingLists.Commands;
using Listomora.Application.Features.ShoppingLists.Queries;
using Listomora.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Listomora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingListController(IMediator mediator)
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
                return Ok(await _mediator.Send(new GetAllShoppingListsQuery()));
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
                return Ok(await _mediator.Send(new GetMyShoppingListsQuery(new Guid(userId))));
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
                ShoppingListDetailsDto shoppinglist;
                if (role == UserRole.ADMIN.ToString())
                    shoppinglist = await _mediator.Send(new GetShoppingListByIdQuery(id));
                else
                {
                    string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    shoppinglist = await _mediator.Send(new GetShoppingListByIdQuery(id, new Guid(userId)));
                }
                if (shoppinglist is null)
                    return NotFound();
                return Ok(shoppinglist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] ShoppingListCreateDto dto)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid id = await _mediator.Send(new CreateShoppingListCommand(dto, new Guid(userId)));
                return Ok(id);
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
        public async Task<IActionResult> Update(Guid id, [FromBody] ShoppingListUpdateDto dto)
        {
            try
            {
                string? role = User.FindFirst(ClaimTypes.Role)?.Value;
                if (role == UserRole.ADMIN.ToString())
                {
                    await _mediator.Send(new UpdateShoppingListCommand(id, dto));
                    return Ok();
                }
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _mediator.Send(new UpdateShoppingListCommand(id, dto, new Guid(userId)));
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
                    await _mediator.Send(new DeleteShoppingListCommand(id));
                    return Ok();
                }
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _mediator.Send(new DeleteShoppingListCommand(id, new Guid(userId)));
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
        
        //TODO : ajouter check creatorId ou role admin via shoppingList
        [HttpPatch("lines")]
        [Authorize(Policy = "Authenticated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLines([FromBody] IEnumerable<ShoppingListLineCreateUpdateDto> dtos)
        {
            try
            {
                await _mediator.Send(new UpdateShoppingListLinesCommand(dtos));
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
    }
}
