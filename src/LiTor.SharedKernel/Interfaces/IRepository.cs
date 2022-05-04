using Ardalis.Specification;

namespace LiTor.SharedKernel.Interfaces
{
    // from Ardalis.Specification
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
