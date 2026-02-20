using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Features.Articles.Commands;
using Listomora.Application.Features.Articles.Queries;
using Listomora.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Listomora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        [Authorize(Policy = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                return Ok(await _mediator.Send(new GetArticlesQuery()));
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
                return Ok(await _mediator.Send(new GetPublicArticlesQuery()));
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
                ArticleDetailsDto article;
                if (role == UserRole.ADMIN.ToString())
                     article = await _mediator.Send(new GetArticleByIdQuery(id));
                else
                {
                    string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    article = await _mediator.Send(new GetArticleByIdQuery(id, new Guid(userId)));
                }
                if (article is null)
                    return NotFound();
                return Ok(article);
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
        public async Task<IActionResult> Insert([FromBody] ArticleCreateUpdateDto dto)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var created = await _mediator.Send(new CreateArticleCommand(dto, new Guid(userId)));
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
        public async Task<IActionResult> Update(Guid id, [FromBody] ArticleCreateUpdateDto dto)
        {
            try
            {
                string? role = User.FindFirst(ClaimTypes.Role)?.Value;
                if (role == UserRole.ADMIN.ToString())
                {
                    await _mediator.Send(new UpdateArticleCommand(id, dto));
                    return Ok();
                }
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _mediator.Send(new UpdateArticleCommand(id, dto, new Guid(userId)));
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
                    await _mediator.Send(new DeleteArticleCommand(id));
                    return Ok();
                }
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _mediator.Send(new DeleteArticleCommand(id, new Guid(userId)));
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
