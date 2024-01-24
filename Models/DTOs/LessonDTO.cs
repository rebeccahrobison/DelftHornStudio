namespace DelftHornStudio.Models.DTOs;

public class LessonDTO
{
  public int Id { get; set; }
  public int StudentId { get; set; }
  public DateTime DateScheduled { get; set; }
  public bool isCompleted { get; set; }
  public decimal Price { get; set; }
  public bool isPaid { get; set; }
  public List<LessonRepertoireDTO>? LessonRepertoires { get; set; }
  public StudentDTO? Student { get; set; }
}