namespace DelftHornStudio.Models.DTOs;

public class StudentDTO
{
  public int Id { get; set; }
  public int UserProfileId { get; set; }
  public int Grade { get; set; }
  public string Phone { get; set; }
  public string ParentName { get; set; }
  public string ParentEmail { get; set; }
  public string ParentPhone { get; set; }
  public string ParentAddress { get; set; }
  public bool isActive { get; set; }
  public List<LessonDTO> Lessons { get; set; }
  public UserProfileDTO? UserProfile { get; set; }
  public decimal? Balance
  {
    get
    {
      if (Lessons == null)
      {
        return null;
      }
      var completedUnpaidLessons = Lessons.Where(l => l.isCompleted && !l.isPaid);
      var balance = completedUnpaidLessons.Sum(c => c.Price);
      return balance;
    }
  }
}