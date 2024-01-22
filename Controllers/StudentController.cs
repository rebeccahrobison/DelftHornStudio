using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DelftHornStudio.Data;
using Microsoft.EntityFrameworkCore;
using DelftHornStudio.Models;
using DelftHornStudio.Models.DTOs;

namespace DelftHornStudio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
  private DelftHornStudioDbContext _dbContext;

  public StudentController(DelftHornStudioDbContext context)
  {
    _dbContext = context;
  }

  [HttpGet]
  [Authorize]
  public IActionResult Get()
  {
    return Ok(_dbContext
      .Students
      .Include(s => s.Lessons)
        .ThenInclude(l => l.LessonRepertoires)
      .Include(s => s.UserProfile)
        .ThenInclude(up => up.IdentityUser)
      .OrderByDescending(s => s.isActive)
      .ThenByDescending(s => s.UserProfile.LastName)
      .Select(s => new StudentDTO
      {
        Id = s.Id,
        UserProfileId = s.UserProfileId,
        Grade = s.Grade,
        Phone = s.Phone,
        ParentName = s.ParentName,
        ParentEmail = s.ParentEmail,
        ParentAddress = s.ParentAddress,
        ParentPhone = s.ParentPhone,
        isActive = s.isActive,
        UserProfile = new UserProfileDTO
        {
          Id = s.UserProfile.Id,
          FirstName = s.UserProfile.FirstName,
          LastName = s.UserProfile.LastName,
          Address = s.UserProfile.Address,
          Email = s.UserProfile.IdentityUser.Email
        },
        Lessons = s.Lessons.Select(l => new LessonDTO
        {
          Id = l.Id,
          DateScheduled = l.DateScheduled,
          isCompleted = l.isCompleted,
          Price = l.Price,
          isPaid = l.isPaid,
          LessonRepertoires = l.LessonRepertoires.Select(lr => new LessonRepertoireDTO
          {
            Id = lr.Id,
            LessonId = lr.LessonId,
            RepertoireId = lr.RepertoireId,
            Repertoire = new RepertoireDTO
            {
              Id = lr.Repertoire.Id,
              Title = lr.Repertoire.Title,
              Author = lr.Repertoire.Author,
              Image = lr.Repertoire.Image
            }
          }).ToList()
        }).ToList()
      })
      );
  }
}