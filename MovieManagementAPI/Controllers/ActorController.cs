using Microsoft.AspNetCore.Mvc;
using MovieManagement.Domain.IRepositories;

namespace MovieManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public ActorController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var accActors = await _unitOfWork.Actor.GetAllAsync();
        return Ok(accActors);
    }

    [HttpGet("movies")]
    public async Task<ActionResult> GetMoviesWithActors()
    {
        var accActors = await _unitOfWork.Actor.GetActorsWithMoviesAsync();
        return Ok(accActors);
    }
}