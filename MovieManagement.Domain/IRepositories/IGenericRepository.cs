using System.Linq.Expressions;

namespace MovieManagement.Domain.IRepositories;

public interface IGenericRepository   <T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
}