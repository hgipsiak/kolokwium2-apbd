using System.ComponentModel.DataAnnotations.Schema;

namespace kol2.Models;

public class Available_Program
{
    public int AvailableProgramId { get; set; }
    [ForeignKey(nameof(Washing_Machine))]
    public int WashingMachineId { get; set; }
    [ForeignKey(nameof(Program))]
    public int ProgramId { get; set; }
    public decimal Price { get; set; }

    public Washing_Machine Washing_Machine { get; set; } = null!;
    public ProgramEntity Program { get; set; } = null!;
    
    public ICollection<Purchase_History> PurchaseHistories { get; set; } = null!;
}