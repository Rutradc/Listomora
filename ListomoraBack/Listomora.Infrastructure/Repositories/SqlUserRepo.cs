using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using Listomora.Domain.Models;
using Listomora.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Listomora.Infrastructure.Repositories
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly ListomoraDbContext _dbContext;

        public SqlUserRepo(ListomoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
        }

        // TODO : ajouter token de création de compte
        public async Task<bool> RegisterAsync(UserCreateDto user)
        {
            CreationToken token = await _dbContext.CreationTokens.SingleOrDefaultAsync(c => c.TokenHash == user.CreationToken);
            if (token == null)
                return false;
            if (token.ExpiresAt < DateTime.UtcNow)
                throw new Exception("Token has expired at " + token.ExpiresAt + " .");
            if (token.UsedAt is not null)
                throw new Exception("Token has already been used at " + token.UsedAt + " .");
            _dbContext.Users.Add(user.ToEntity());
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UserProfileDto> GetProfileByIdAsync(Guid id)
        {
            return (await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id)).ToProfileDto();
        }

        public async Task<UserNavDto> GetNavByIdAsync(Guid id)
        {
            return (await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id)).ToNavDto();
        }

        public async Task<bool> UpdateAsync(Guid id, UserUpdateDto dto)
        {
            User userToUpdate;

            userToUpdate = await _dbContext.Users.SingleOrDefaultAsync(a => a.Id == id);
            if (userToUpdate is null)
                return false;
            userToUpdate.FirstName = dto.FirstName;
            userToUpdate.LastName = dto.LastName;
            userToUpdate.Email = dto.Email;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateCreationTokenAsync(CreationTokenCreateDto dto)
        {
            _dbContext.CreationTokens.Add(dto.ToEntity());
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckCreationTokenAsync(string tokenHash)
        {
            CreationToken token = await _dbContext.CreationTokens.SingleOrDefaultAsync(c => c.TokenHash == tokenHash);
            if (token == null) 
                return false;
            if (token.ExpiresAt < DateTime.UtcNow)
                throw new Exception("Token has expired at " + token.ExpiresAt + " .");
            if (token.UsedAt is not null)
                throw new Exception("Token has already been used at " + token.UsedAt + " .");
            return true;
        }
    }
}
