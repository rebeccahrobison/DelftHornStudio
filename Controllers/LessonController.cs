using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DelftHornStudio.Data;
using Microsoft.EntityFrameworkCore;
using DelftHornStudio.Models;
using DelftHornStudio.Models.DTOs;

namespace DelftHornStudio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
  private DelftHornStudioDbContext _dbContext;

  public LessonController(DelftHornStudioDbContext context)
  {
    _dbContext = context;
  }

  [HttpGet]
  [Authorize]
  public IActionResult Get()
  {
    return Ok(_dbContext.Lessons
      .Include(l => l.Student)
        .ThenInclude(s => s.UserProfile)
      .Include(l => l.LessonRepertoires)
        .ThenInclude(lr => lr.Repertoire)
      .OrderByDescending(l => l.DateScheduled)
      .Select(l => new LessonDTO
      {
        Id = l.Id,
        StudentId = l.StudentId,
        DateScheduled = l.DateScheduled,
        isCompleted = l.isCompleted,
        Price = l.Price,
        isPaid = l.isPaid,
        Student = new StudentDTO
        {
          Id = l.Student.Id,
          UserProfileId = l.Student.UserProfileId,
          Grade = l.Student.Grade,
          Phone = l.Student.Phone,
          ParentName = l.Student.ParentName,
          ParentEmail = l.Student.ParentEmail,
          ParentAddress = l.Student.ParentAddress,
          ParentPhone = l.Student.ParentPhone,
          isActive = l.Student.isActive,
          UserProfile = new UserProfileDTO
          {
            Id = l.Student.UserProfile.Id,
            FirstName = l.Student.UserProfile.FirstName,
            LastName = l.Student.UserProfile.LastName,
            Address = l.Student.UserProfile.Address,
            Email = l.Student.UserProfile.IdentityUser.Email
          },
        },
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
    );
  }

  [HttpPost]
  [Authorize]
  public IActionResult PostLesson (Lesson lesson)
  {

    _dbContext.Lessons.Add(lesson);
    _dbContext.SaveChanges();

    lesson.LessonRepertoires = _dbContext.LessonRepertoires
      .Where(lr => lr.LessonId == lesson.Id).ToList();

    return Created($"/api/lesson/{lesson.Id}", lesson);
  }
}