using MovieManagement.Domain.Entities;
using MovieManagement.Domain.IServices;

namespace MovieManagement.Application.Services;

public class MovieService : IMovieService
{
    public MovieService()
    {
        
    }
    public List<Movie> GetAllMovies()
    {
        throw new NotImplementedException();
    }
}