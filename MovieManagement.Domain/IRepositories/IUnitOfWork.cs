namespace MovieManagement.Domain.IRepositories;

public interface IUnitOfWork :IDisposable
{
     IActorRepository Actor { get; }
     IMovieRepository Movie { get;  }
     IGenreRepository Genre { get; }
     IBiographyRepository Biography { get; }

     int Save();

}