using MediatR;
using MovieManagement.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Application.Features.Actor.Queries
{
    public class GetAllActorsQuery : IRequest<ICollection<Domain.Entities.Actor>> { }

    public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, ICollection<Domain.Entities.Actor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllActorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICollection<Domain.Entities.Actor>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            var actors = await _unitOfWork.Actor.GetAllAsync();
            return actors.ToList(); 
        }

    }
}
