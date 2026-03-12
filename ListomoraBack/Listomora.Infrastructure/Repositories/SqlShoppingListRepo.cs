using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using Listomora.Domain.Models;
using Listomora.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Listomora.Infrastructure.Repositories
{
    public class SqlShoppingListRepo : IShoppingListRepo
    {
        private readonly ListomoraDbContext _dbContext;

        public SqlShoppingListRepo(ListomoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ShoppingListListDto>> GetAllAsync()
        {
            return await _dbContext.ShoppingLists.Select(s => s.ToListDto()).ToListAsync();
        }
        public async Task<IEnumerable<ShoppingListListDto>> GetMineAsync(Guid creatorId)
        {
            return await _dbContext.ShoppingLists.Where(s => s.CreatorId == creatorId).Select(s => s.ToListDto()).ToListAsync();
        }

        public async Task<ShoppingListDetailsDto> GetByIdAsync(Guid id, Guid? userId)
        {
            if (userId is null)
                return await _dbContext.ShoppingLists.Include(s => s.ShoppingListLines).ThenInclude(sl => sl.Article).Select(s => s.ToDetailsDto()).FirstOrDefaultAsync(s => s.Id == id);
            else
                return await _dbContext.ShoppingLists.Include(s => s.ShoppingListLines).ThenInclude(sl => sl.Article).Where(s => s.CreatorId == userId).Select(s => s.ToDetailsDto()).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> InsertAsync(ShoppingListCreateUpdateDto dto, Guid creatorId)
        {
            _dbContext.ShoppingLists.Add(dto.ToEntity());
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertLineAsync(ShoppingListLineCreateDto dto, Guid creatorId)
        {
            _dbContext.ShoppingListLines.Add(dto.ToEntity());
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, ShoppingListCreateUpdateDto dto, Guid? userId)
        {
            ShoppingList shoppingListToUpdate;
            if (userId is null)
                shoppingListToUpdate = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id);
            else
                shoppingListToUpdate = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id && s.CreatorId == (Guid)userId);
            if (shoppingListToUpdate is null)
                return false;
            shoppingListToUpdate.Name = dto.Name;
            shoppingListToUpdate.IsTemplate = dto.IsTemplate;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateLineAsync(Guid articleId, Guid shoppingListId, ShoppingListLineUpdateDto dto)
        {
            ShoppingListLine shoppingListLineToUpdate;
            shoppingListLineToUpdate = await _dbContext.ShoppingListLines.SingleOrDefaultAsync(s => s.ArticleId == articleId && s.ShoppingListId == shoppingListId);
            if (shoppingListLineToUpdate is null)
                return false;
            shoppingListLineToUpdate.Amount = dto.Amount;
            shoppingListLineToUpdate.Unit = dto.Unit;
            shoppingListLineToUpdate.Price = dto.Price;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id, Guid? userId)
        {
            ShoppingList shoppingList;
            if (userId is null)
                shoppingList = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id);
            else
                shoppingList = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id && s.CreatorId == userId);
            if (shoppingList is null)
                return false;
            _dbContext.ShoppingLists.Remove(shoppingList);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLineAsync(Guid articleId, Guid shoppingListId)
        {
            ShoppingListLine shoppingListLine;
            shoppingListLine = await _dbContext.ShoppingListLines.FirstOrDefaultAsync(s => s.ArticleId == articleId && s.ShoppingListId == shoppingListId);
            if (shoppingListLine is null)
                return false;
            _dbContext.ShoppingListLines.Remove(shoppingListLine);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CompleteShoppingList(Guid id, bool isDone, Guid? userId)
        {
            ShoppingList shoppingListToUpdate;
            if (userId is null)
                shoppingListToUpdate = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id);
            else
                shoppingListToUpdate = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id && s.CreatorId == (Guid)userId);
            if (shoppingListToUpdate is null)
                return false;
            if (isDone && !shoppingListToUpdate.IsDone)
                shoppingListToUpdate.DoneAt = DateTime.UtcNow;
            shoppingListToUpdate.IsDone = isDone;
            if (!isDone)
                shoppingListToUpdate.DoneAt = null;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
