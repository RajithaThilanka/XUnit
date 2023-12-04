using MediatR;
using MovieManagement.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Application.Features.Actor.Queries
{
  public class GetAllActorsWithMoviesQuery : IRequest<ICollection<Domain.Entities.Actor>> { }

    public class GetAllActorsWithMoviesQueryHandler : IRequestHandler<GetAllActorsWithMoviesQuery, ICollection<Domain.Entities.Actor>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllActorsWithMoviesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICollection<Domain.Entities.Actor>> Handle(GetAllActorsWithMoviesQuery request, CancellationToken cancellationToken)
        {
            var actors = await _unitOfWork.Actor.GetActorsWithMoviesAsync();
            return actors.ToList();
        }
    }

}
