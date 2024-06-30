using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;
using TtcApi.Data;

namespace TtcApi.Repositories
{
    public class ShipRepository : IShipRepository
    {
        private readonly TTCContext _context;

        public ShipRepository(TTCContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ship>> GetShipsAsync()
        {
            return await _context.Ships.ToListAsync();
        }

        public async Task<Ship> GetShipAsync(string shipName)
        {
            return await _context.Ships.FindAsync(shipName);
        }

        public async Task<Ship> GetShipByEmailAsync(string email)
        {
            return await _context.Ships.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task AddShipAsync(Ship ship)
        {
            _context.Ships.Add(ship);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShipAsync(Ship ship)
        {
            _context.Entry(ship).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShipAsync(string shipName)
        {
            var ship = await _context.Ships.FindAsync(shipName);
            if (ship != null)
            {
                _context.Ships.Remove(ship);
                await _context.SaveChangesAsync();
            }
        }
    }
}
