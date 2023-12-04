using MovieManagement.Domain.Entities;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Infrastructure.Context;

namespace MovieManagement.Infrastructure.Persistence.Repositories;

public class BiographyRepository: GenericRepository<Biography>  ,IBiographyRepository
{    
    private readonly MovieManagementDbContext _context;
    public BiographyRepository( MovieManagementDbContext context):base(context)
    {
        _context = context;
    }
}