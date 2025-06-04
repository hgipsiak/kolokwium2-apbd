namespace kol2.Models;

public class ProgramEntity
{
    public int ProgramId { get; set; }
    public string Name { get; set; }
    public int DurationMinutes { get; set; }
    public int TemperatureCelsius { get; set; }

    public ICollection<Available_Program> AvailablePrograms { get; set; } = null!;

}