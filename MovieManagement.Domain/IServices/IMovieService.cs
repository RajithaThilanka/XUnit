using MovieManagement.Domain.Entities;

namespace MovieManagement.Domain.IServices;

public interface IMovieService
{
    List<Movie> GetAllMovies();
    
}