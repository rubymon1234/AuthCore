using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;
using System.ComponentModel.Design;

namespace ShoppyWeb.Models.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ApplicationUserRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
    }
}
