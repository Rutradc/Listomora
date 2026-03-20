using Listomora.Application.Contracts.Persistence.CustomExceptions;
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

        public async Task<ShoppingListDetailsDto> GetByIdAsync(Guid id, Guid? userId = null)
        {
            if (userId is null)
                return (await _dbContext.ShoppingLists.Include(s => s.ShoppingListLines).ThenInclude(sl => sl.Article).SingleOrDefaultAsync(s => s.Id == id)).ToDetailsDto();
            else
                return (await _dbContext.ShoppingLists.Include(s => s.ShoppingListLines).ThenInclude(sl => sl.Article).SingleOrDefaultAsync(s => s.Id == id && s.CreatorId == userId)).ToDetailsDto();
        }

        public async Task<Guid> InsertAsync(ShoppingListCreateDto dto, Guid creatorId)
        {
            var entity = dto.ToEntity(creatorId);
            _dbContext.ShoppingLists.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, ShoppingListUpdateDto dto, Guid? userId = null)
        {
            ShoppingList shoppingListToUpdate;
            if (userId is null)
                shoppingListToUpdate = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id);
            else
                shoppingListToUpdate = await _dbContext.ShoppingLists.SingleOrDefaultAsync(s => s.Id == id && s.CreatorId == (Guid)userId);
            if (shoppingListToUpdate is null)
                return false;
            shoppingListToUpdate.Name = dto.Name;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid? userId = null)
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

        public async Task<bool> CompleteShoppingList(Guid id, bool isDone, Guid? userId = null)
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

        public async Task<bool> UpdateLinesAsync(ShoppingListLinesUpdateDto dto)
        {
            Guid shoppingListId = dto.ShoppingListId;

            // delete
            IEnumerable<ShoppingListLine> linesToRemove = await _dbContext.ShoppingListLines.Where(l => l.ShoppingListId == shoppingListId && dto.RemovedLinesArticleIds.Contains(l.ArticleId)).ToListAsync();
            if (linesToRemove.ToList().Count != dto.RemovedLinesArticleIds.Count)
                throw new NotFoundException($"{dto.RemovedLinesArticleIds.Count - linesToRemove.ToList().Count} line(s) to delete was(were) not found.");
            _dbContext.ShoppingListLines.RemoveRange(linesToRemove);

            // update
            IEnumerable<ShoppingListLine> linesToUpdate = _dbContext.ShoppingListLines.Where(l => dto.UpdatedLines.Select(x => x.ArticleId).Contains(l.ArticleId) && l.ShoppingListId == shoppingListId);
            foreach (ShoppingListLine line in linesToUpdate)
            {
                ShoppingListLineCreateUpdateDto? lineUpdated = dto.UpdatedLines.SingleOrDefault(x => x.OriginArticleId == line.ArticleId);
                if (lineUpdated is null)
                    throw new NotFoundException("At least one of the lines to update was not found.");
                line.ArticleId = lineUpdated.ArticleId;
                line.Amount = lineUpdated.Amount;
                line.Unit = lineUpdated.Unit;
                line.Price = lineUpdated.Price;
            };
            _dbContext.ShoppingListLines.UpdateRange(linesToUpdate);

            // insert

            var linesToAdd = dto.AddedLines.Select(x => x.ToEntity());
            _dbContext.ShoppingListLines.AddRange(linesToAdd);

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
