using LiTor.SharedKernel.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;

namespace LiTor.Infrastructure.Data
{
    // inherit from Ardalis.Specification type
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
