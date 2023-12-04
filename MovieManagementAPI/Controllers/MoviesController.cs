
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Infrastructure.Persistence.Repositories;

namespace MovieManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork; 
        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult>  Get()
        {
            var accActors = await _unitOfWork.Movie.GetAllAsync();
            return Ok(accActors);
        }
    }
}
