namespace kol2.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; } = null!;
    
    public ICollection<Purchase_History> PurchaseHistories { get; set; } = null!;
}