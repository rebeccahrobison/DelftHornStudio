namespace DelftHornStudio.Models;

public class LessonRepertoire
{
  public int Id { get; set; }
  public int LessonId { get; set; }
  public int RepertoireId { get; set; }
  public Repertoire? Repertoire { get; set; }
}
