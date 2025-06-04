using kol2.DTOs;

namespace kol2.Services;

public interface IDbService
{
    Task<GetOrdersDto> GetOrders(int customerId);
}