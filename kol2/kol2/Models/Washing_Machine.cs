namespace kol2.Models;

public class Washing_Machine
{
    public int WashingMachineId { get; set; }
    public decimal MaxWeight { get; set; }
    public string SerialNumber { get; set; }

    public ICollection<Available_Program> AvailablePrograms { get; set; } = null!;
}