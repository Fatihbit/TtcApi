using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TtcApi.Data;
using TtcApi.Models;

namespace TtcApi.Repositories
{
    public class LadingRepository : ILadingRepository
    {
        private readonly TTCContext _context;

        public LadingRepository(TTCContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lading>> GetLadingsAsync()
        {
            return await _context.Ladings
                                 .Include(l => l.Ship)
                                 .Include(l => l.Terminal)
                                 .Include(l => l.Product)
                                 .ToListAsync();
        }

        public async Task<Lading> GetLadingByIdAsync(int id)
        {
            return await _context.Ladings
                                 .Include(l => l.Ship)
                                 .Include(l => l.Terminal)
                                 .Include(l => l.Product)
                                 .FirstOrDefaultAsync(l => l.LadingId == id);
        }

        public async Task<Ship> GetShipAsync(string shipName)
        {
            return await _context.Ships.FindAsync(shipName);
        }

        public async Task<Terminal> GetTerminalAsync(string terminalName)
        {
            return await _context.Terminals.FindAsync(terminalName);
        }

        public async Task<Product> GetProductAsync(string productName)
        {
            return await _context.Products.FindAsync(productName);
        }

        public async Task<IEnumerable<Lading>> GetLadingsByTerminalNameAsync(string terminalName)
        {
            return await _context.Ladings
                                 .Where(l => l.TerminalName == terminalName)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Lading>> GetLadingsByShipNameAsync(string shipName)
        {
            return await _context.Ladings
                                 .Where(l => l.ShipName == shipName)
                                 .ToListAsync();
        }

        public async Task AddLadingAsync(Lading lading)
        {
            _context.Ladings.Add(lading);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLadingAsync(int id, Lading lading)
        {
            _context.Entry(lading).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLadingAsync(int id)
        {
            var lading = await _context.Ladings.FindAsync(id);
            if (lading != null)
            {
                _context.Ladings.Remove(lading);
                await _context.SaveChangesAsync();
            }
        }
    }
}
