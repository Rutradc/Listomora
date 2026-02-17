using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
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

        public async Task<User> GetAsync(string email)
        {
            return await _dbContext.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
        }

        public Task<bool> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        // TODO : ajouter token de création de compte
        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                _dbContext.Add(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
