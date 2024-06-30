using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;
using TtcApi.Data;

namespace TtcApi.Repositories
{
    public class TerminalRepository : ITerminalRepository
    {
        private readonly TTCContext _context;

        public TerminalRepository(TTCContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Terminal>> GetTerminalsAsync()
        {
            return await _context.Terminals.ToListAsync();
        }

        public async Task<Terminal> GetTerminalAsync(string terminalName)
        {
            return await _context.Terminals.FindAsync(terminalName);
        }

        public async Task<Terminal> GetTerminalByEmailAsync(string email)
        {
            return await _context.Terminals.FirstOrDefaultAsync(t => t.Email == email);
        }

        public async Task AddTerminalAsync(Terminal terminal)
        {
            _context.Terminals.Add(terminal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTerminalAsync(Terminal terminal)
        {
            _context.Entry(terminal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTerminalAsync(string terminalName)
        {
            var terminal = await _context.Terminals.FindAsync(terminalName);
            if (terminal != null)
            {
                _context.Terminals.Remove(terminal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
