namespace DelftHornStudio.Models;

public class Lesson
{
  public int Id { get; set; }
  public int StudentId { get; set; }
  public DateTime DateScheduled { get; set; }
  public bool isCompleted { get; set; }
  public decimal Price { get; set; }
  public bool isPaid { get; set; }
  public List<LessonRepertoire> LessonRepertoires { get; set; }
  public Student? Student { get; set; }
}