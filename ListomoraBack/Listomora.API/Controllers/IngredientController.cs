using Listomora.API.Dto;
using Listomora.API.Handlers;
using Listomora.BLL.Services.Interfaces;
using Listomora.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Listomora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Ingredient ingredient = await _service.GetAsync(id);
            if (ingredient is null)
                return NotFound();
            return Ok(ingredient);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] IngredientCreateUpdateDto dto)
        {
            var created = await _service.InsertAsync(dto.ToEntity());
            return CreatedAtAction(nameof(Insert), new { id = created.Id }, created);
        }
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] IngredientCreateUpdateDto dto)
        {
            Ingredient ingredient = await _service.UpdateAsync(dto.ToEntity(), id);
            if (ingredient is null)
                return NotFound();
            return Ok(ingredient);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _service.DeleteAsync(id))
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
