using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;

namespace TtcApi.Repositories
{
    public interface ILadingRepository
    {
        Task<IEnumerable<Lading>> GetLadingsAsync();
        Task<Lading> GetLadingByIdAsync(int id);
        Task<Ship> GetShipAsync(string shipName);
        Task<Terminal> GetTerminalAsync(string terminalName);
        Task<Product> GetProductAsync(string productName);
        Task<IEnumerable<Lading>> GetLadingsByTerminalNameAsync(string terminalName);
        Task<IEnumerable<Lading>> GetLadingsByShipNameAsync(string shipName);
        Task AddLadingAsync(Lading lading);
        Task UpdateLadingAsync(int id, Lading lading);
        Task DeleteLadingAsync(int id);
    }
}
