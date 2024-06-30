using TtcApi.Models;

public interface IShipRepository
{
    Task<Ship> GetShipByEmailAsync(string email);
    Task<IEnumerable<Ship>> GetShipsAsync();
    Task<Ship> GetShipAsync(string shipName);
    Task AddShipAsync(Ship ship);
    Task UpdateShipAsync(Ship ship);
    Task DeleteShipAsync(string shipName);
}
