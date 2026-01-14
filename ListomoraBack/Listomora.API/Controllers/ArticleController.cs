using Listomora.API.Dto;
using Listomora.API.Handlers;
using Listomora.BLL.Services.Interfaces;
using Listomora.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Listomora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }
        //[Authorize(Policy = "Member")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        //[Authorize(Policy = "Member")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Article article = await _service.GetAsync(id);
            if (article is null)
                return NotFound();
            return Ok(article);
        }
        //[Authorize(Policy = "Member")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ArticleCreateUpdateDto dto)
        {
            var created = await _service.InsertAsync(dto.ToEntity());
            return CreatedAtAction(nameof(Insert),new { id = created.Id }, created);
        }
        //[Authorize(Policy = "Member")]
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ArticleCreateUpdateDto dto)
        {
            Article article = await _service.UpdateAsync(dto.ToEntity(), id);
            if (article is null)
                return NotFound();
            return Ok(article);
        }
        //[Authorize(Policy = "Member")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _service.DeleteAsync(id))
                return Ok();
            return NotFound();
        }
    }
}
