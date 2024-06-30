using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.DTOs;

namespace TtcApi.Repositories
{
    public interface IVeiligheidsChecklistRepository
    {
        Task<IEnumerable<VeiligheidsChecklistDTO>> GetVeiligheidsChecklistsAsync();
        Task<VeiligheidsChecklistDTO> GetVeiligheidsChecklistByIdAsync(int id);
        Task AddVeiligheidsChecklistAsync(VeiligheidsChecklistDTO checklist);
        Task UpdateVeiligheidsChecklistAsync(VeiligheidsChecklistDTO checklist);
        Task DeleteVeiligheidsChecklistAsync(int id);
    }
}
