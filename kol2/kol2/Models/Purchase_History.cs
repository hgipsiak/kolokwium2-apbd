using System.ComponentModel.DataAnnotations.Schema;

namespace kol2.Models;

public class Purchase_History
{
    [ForeignKey(nameof(Available_Program))]
    public int AvailableProgramId { get; set; }
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int? Rating { get; set; } = null!;

    public ICollection<Available_Program> AvailablePrograms { get; set; } = null!;
}