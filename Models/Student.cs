namespace DelftHornStudio.Models;

public class Student
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
  public List<Lesson> Lessons { get; set; }
  public UserProfile UserProfile { get; set; }
}