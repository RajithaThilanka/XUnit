//using MediatR;
//using MovieManagement.Domain.IRepositories;

//namespace MovieManagement.Application.Features.Movie.Queries;

//public class GetAllMoviesQuery : IRequest<ICollection<Domain.Entities.Movie>> { }

//public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, ICollection<Domain.Entities.Movie>>
//{
//    private readonly IUnitOfWork _unitOfWork;

//    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    public async Task<ICollection<Domain.Entities.Movie>> Handle( GetAllMoviesQuery request,CancellationToken cancellationToken)
//    {
//        var movies = await _unitOfWork.Movie.GetAll();
//        var movieList = movies.ToList(); 
//        return movieList;
//    }


//}