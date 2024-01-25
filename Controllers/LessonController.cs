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
  public IActionResult PostLesson(Lesson lesson)
  {

    _dbContext.Lessons.Add(lesson);
    _dbContext.SaveChanges();

    lesson.LessonRepertoires = _dbContext.LessonRepertoires
      .Where(lr => lr.LessonId == lesson.Id).ToList();

    return Created($"/api/lesson/{lesson.Id}", lesson);
  }

  [HttpGet("{id}")]
  [Authorize]
  public IActionResult GetLessonById(int id)
  {
    Lesson lesson = _dbContext.Lessons
      .Include(l => l.Student)
        .ThenInclude(s => s.UserProfile)
          .ThenInclude(up => up.IdentityUser)
      .Include(l => l.LessonRepertoires)
        .ThenInclude(lr => lr.Repertoire)
      .SingleOrDefault(l => l.Id == id);

    if (lesson == null)
    {
      return NotFound();
    }

    return Ok(new LessonDTO
    {
      Id = lesson.Id,
      StudentId = lesson.StudentId,
      DateScheduled = lesson.DateScheduled,
      isCompleted = lesson.isCompleted,
      Price = lesson.Price,
      isPaid = lesson.isPaid,
      Student = new StudentDTO
      {
        Id = lesson.Student.Id,
        UserProfileId = lesson.Student.UserProfileId,
        Grade = lesson.Student.Grade,
        Phone = lesson.Student.Phone,
        ParentName = lesson.Student.ParentName,
        ParentEmail = lesson.Student.ParentEmail,
        ParentAddress = lesson.Student.ParentAddress,
        ParentPhone = lesson.Student.ParentPhone,
        isActive = lesson.Student.isActive,
        UserProfile = lesson.Student?.UserProfile != null ? new UserProfileDTO
        {
          Id = lesson.Student.UserProfile.Id,
          FirstName = lesson.Student.UserProfile.FirstName,
          LastName = lesson.Student.UserProfile.LastName,
          Address = lesson.Student.UserProfile.Address,
          Email = lesson.Student.UserProfile.IdentityUser.Email,
          IdentityUserId = lesson.Student.UserProfile.IdentityUserId,
          IdentityUser = lesson.Student.UserProfile.IdentityUser
        } : null,
      },
      LessonRepertoires = lesson.LessonRepertoires?.Select(lr => new LessonRepertoireDTO
      {
        Id = lr.Id,
        LessonId = lr.LessonId,
        RepertoireId = lr.RepertoireId,
        Repertoire = lr.Repertoire != null ? new RepertoireDTO
        {
          Id = lr.Repertoire.Id,
          Title = lr.Repertoire.Title,
          Author = lr.Repertoire.Author,
          Image = lr.Repertoire.Image
        } : null
      }).ToList()
    });
  }

  [HttpDelete("{id}")]
  [Authorize]
  public IActionResult DeleteLesson (int id)
  {
    Lesson lessonToDelete = _dbContext.Lessons.SingleOrDefault(l => l.Id == id);
    if (lessonToDelete == null)
    {
      return NotFound();
    }
     _dbContext.Lessons.Remove(lessonToDelete);
     _dbContext.SaveChanges();

     return NoContent();
  }

  //TODO HttpPut
}