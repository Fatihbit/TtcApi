using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Data;
using TtcApi.Models;

namespace TtcApi.Repositories
{
    public class StatusLadingRepository : IStatusLadingRepository
    {
        private readonly TTCContext _context;

        public StatusLadingRepository(TTCContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StatusLading>> GetStatusLadingsAsync()
        {
            return await _context.StatusLadings.ToListAsync();
        }

        public async Task<StatusLading> GetStatusLadingByIdAsync(int id)
        {
            return await _context.StatusLadings.FindAsync(id);
        }

        public async Task<StatusLading> GetStatusLadingByLadingIdAsync(int ladingId)
        {
            return await _context.StatusLadings.FirstOrDefaultAsync(sl => sl.LadingId == ladingId);
        }

        public async Task AddStatusLadingAsync(StatusLading statusLading)
        {
            _context.StatusLadings.Add(statusLading);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusLadingAsync(StatusLading statusLading)
        {
            _context.Entry(statusLading).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatusLadingAsync(int id)
        {
            var statusLading = await _context.StatusLadings.FindAsync(id);
            if (statusLading != null)
            {
                _context.StatusLadings.Remove(statusLading);
                await _context.SaveChangesAsync();
            }
        }
    }
}
