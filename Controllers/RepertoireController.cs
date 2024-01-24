using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DelftHornStudio.Data;
using Microsoft.EntityFrameworkCore;
using DelftHornStudio.Models;
using DelftHornStudio.Models.DTOs;

namespace DelftHornStudio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepertoireController : ControllerBase
{
  private DelftHornStudioDbContext _dbContext;

  public RepertoireController(DelftHornStudioDbContext context)
  {
    _dbContext = context;
  }

  [HttpGet]
  [Authorize]
  public IActionResult Get()
  {
    return Ok(_dbContext.Repertoires.Select(r => new RepertoireDTO
    {
      Id = r.Id,
      Title = r.Title,
      Author = r.Author,
      Image = r.Image
    }).ToList());
  }
}