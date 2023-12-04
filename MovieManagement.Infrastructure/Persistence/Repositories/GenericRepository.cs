using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Infrastructure.Context;

namespace MovieManagement.Infrastructure.Persistence.Repositories;
       
public class GenericRepository<T> : IGenericRepository<T> where T : class
{ 
    public readonly MovieManagementDbContext _context;
    public GenericRepository(MovieManagementDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync() 
    {
        return await _context.Set<T>().ToListAsync();
    }
}