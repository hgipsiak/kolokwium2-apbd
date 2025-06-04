namespace kol2.DTOs;

public class GetOrdersDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public List<GetPurchaseDto> Purchases { get; set; }
}

public class GetPurchaseDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public decimal? Price { get; set; }
    public GetWashingMachineDto WashingMachine { get; set; }
    public GetProgramDto Program { get; set; }
}

public class GetWashingMachineDto
{
    public string Serial { get; set; }
    public decimal MaxWeight { get; set; }
}

public class GetProgramDto
{
    public string Name { get; set; }
    public int Duration { get; set; }
}