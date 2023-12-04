using MovieManagement.Domain.Entities;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Infrastructure.Context;

namespace MovieManagement.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MovieManagementDbContext _context;
    public UnitOfWork(MovieManagementDbContext context)
    {
        _context = context;
        Actor = new ActorRepository(_context);
        Movie = new MovieRepository(_context);
        Genre = new GenreRepository(_context);
        Biography = new BiographyRepository(_context);
    }

    public IActorRepository Actor { get; private set; }
    public IMovieRepository Movie { get; private set;  }       
    public IGenreRepository Genre { get; private set;}
    public IBiographyRepository Biography { get; private set; }

   public int Save() {
        return _context.SaveChanges();
    }

   public void Dispose()
   {   
       _context.Dispose();
   }
}