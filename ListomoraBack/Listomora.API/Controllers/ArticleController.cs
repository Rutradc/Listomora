using Listomora.API.Dto;
using Listomora.API.Handlers;
using Listomora.Application.Features.Articles.Commands;
using Listomora.Application.Features.Articles.Queries;
using Listomora.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //[Authorize(Policy = "Member")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetArticlesQuery()));
        //[Authorize(Policy = "Member")]
        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    Article article = await _service.GetAsync(id);
        //    if (article is null)
        //        return NotFound();
        //    return Ok(article);
        //}
        //[Authorize(Policy = "Member")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ArticleCreateUpdateDto dto)
        {
            var created = await _mediator.Send(new CreateArticleCommand(dto.Name, dto.IsPublic));
            return Created();
        }
        //[Authorize(Policy = "Member")]
        //[HttpPatch("{id:guid}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] ArticleCreateUpdateDto dto)
        //{
        //    Article article = await _service.UpdateAsync(dto.ToEntity(), id);
        //    if (article is null)
        //        return NotFound();
        //    return Ok(article);
        //}
        ////[Authorize(Policy = "Member")]
        //[HttpDelete("{id:guid}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        if (await _service.DeleteAsync(id))
        //            return Ok();
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}
