using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Infrastructure.Context;

namespace MovieManagement.Infrastructure.Persistence.Repositories;

public class ActorRepository : GenericRepository<Actor>  ,IActorRepository
{ 
    private readonly MovieManagementDbContext _context;
    public ActorRepository( MovieManagementDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Actor>> GetActorsWithMoviesAsync()
    {
        var actorsWithMovies = await _context.Actors.Include(u => u.Movies).ToListAsync();
        return actorsWithMovies;
    }
}