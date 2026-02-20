using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Enums;
using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
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
            _dbContext.Users.Add(user.ToEntity());
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
