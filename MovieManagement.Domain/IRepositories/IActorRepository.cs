using MovieManagement.Domain.Entities;

namespace MovieManagement.Domain.IRepositories;

public interface IActorRepository:IGenericRepository<Actor>
{
  Task<IEnumerable<Actor>>  GetActorsWithMoviesAsync();
}