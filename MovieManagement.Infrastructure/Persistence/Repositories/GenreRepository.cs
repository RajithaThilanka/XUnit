using MovieManagement.Domain.Entities;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Infrastructure.Context;

namespace MovieManagement.Infrastructure.Persistence.Repositories;

public class GenreRepository : GenericRepository<Genre>  ,IGenreRepository
{  
    private readonly MovieManagementDbContext _context;
    public GenreRepository(MovieManagementDbContext context) :base(context)
    {
        _context = context; 
    }
}