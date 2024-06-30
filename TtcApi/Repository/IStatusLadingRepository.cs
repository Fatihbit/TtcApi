using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;

namespace TtcApi.Repositories
{
    public interface IStatusLadingRepository
    {
        Task<IEnumerable<StatusLading>> GetStatusLadingsAsync();
        Task<StatusLading> GetStatusLadingByIdAsync(int id);
        Task<StatusLading> GetStatusLadingByLadingIdAsync(int ladingId);
        Task AddStatusLadingAsync(StatusLading statusLading);
        Task UpdateStatusLadingAsync(StatusLading statusLading);
        Task DeleteStatusLadingAsync(int id);
    }
}
