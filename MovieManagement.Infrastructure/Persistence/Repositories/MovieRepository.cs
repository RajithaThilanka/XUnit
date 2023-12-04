using MovieManagement.Domain.Entities;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Infrastructure.Context;

namespace MovieManagement.Infrastructure.Persistence.Repositories;

public class MovieRepository: GenericRepository<Movie>,IMovieRepository 
{ 
    private readonly MovieManagementDbContext _context;
    public MovieRepository(MovieManagementDbContext context) :base(context)
    {
        _context = context;
    }
}