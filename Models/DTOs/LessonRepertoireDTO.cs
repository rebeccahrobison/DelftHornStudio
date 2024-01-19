namespace DelftHornStudio.Models.DTOs;

public class LessonRepertoireDTO
{
  public int Id { get; set; }
  public int LessonId { get; set; }
  public int RepertoireId { get; set; }
  public RepertoireDTO? Repertoire { get; set; }
}