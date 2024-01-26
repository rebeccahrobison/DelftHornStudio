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
    return Ok(_dbContext.Repertoires
      .OrderBy(r => r.Title)
      .Select(r => new RepertoireDTO
    {
      Id = r.Id,
      Title = r.Title,
      Author = r.Author,
      Image = r.Image
    }).ToList());
  }

  [HttpPost]
  [Authorize]
  public IActionResult PostRepertoire(Repertoire repertoire)
  {
    _dbContext.Repertoires.Add(repertoire);
    _dbContext.SaveChanges();

    return Created($"/api/repertoire/{repertoire.Id}", repertoire);
  }

  [HttpDelete("{id}")]
  [Authorize]
  public IActionResult Delete(int id)
  {
    Repertoire repertoireToDelete = _dbContext.Repertoires.SingleOrDefault(r => r.Id == id);
    if (repertoireToDelete == null)
    {
      return NotFound();
    }

    _dbContext.Remove(repertoireToDelete);
    _dbContext.SaveChanges();

    return NoContent();
  }
}