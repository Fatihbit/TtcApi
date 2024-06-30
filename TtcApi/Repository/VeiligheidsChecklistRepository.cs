using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Data;
using TtcApi.DTOs;
using TtcApi.Models;

namespace TtcApi.Repositories
{
    public class VeiligheidsChecklistRepository : IVeiligheidsChecklistRepository
    {
        private readonly TTCContext _context;

        public VeiligheidsChecklistRepository(TTCContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VeiligheidsChecklistDTO>> GetVeiligheidsChecklistsAsync()
        {
            var checklists = await _context.VeiligheidsChecklists.ToListAsync();
            return checklists.Select(checklist => new VeiligheidsChecklistDTO
            {
                VeiligheidsChecklistId = checklist.VeiligheidsChecklistId,
                LadingId = checklist.LadingId,
                IsSchipGoedGemeerd = checklist.IsSchipGoedGemeerd,
                IsDoeltreffendeVerlichtingVerzekerd = checklist.IsDoeltreffendeVerlichtingVerzekerd,
                IsNooduitgangVrij = checklist.IsNooduitgangVrij,
                IsSchipWalVerbindingVeilig = checklist.IsSchipWalVerbindingVeilig,
                ZijnLaadarmenVrijBeweegbaar = checklist.ZijnLaadarmenVrijBeweegbaar,
                ZijnAansluitingenAfgeblind = checklist.ZijnAansluitingenAfgeblind,
                ZijnLeidingenInGoedeStaat = checklist.ZijnLeidingenInGoedeStaat,
                ZijnAlleKleppenGecontroleerd = checklist.ZijnAlleKleppenGecontroleerd,
                IsAlarmNoodstopBekend = checklist.IsAlarmNoodstopBekend,
                ZijnBrandblusApparatenBedrijfsklaar = checklist.ZijnBrandblusApparatenBedrijfsklaar,
                ZijnVerwarmingsapparatenUitgeschakeld = checklist.ZijnVerwarmingsapparatenUitgeschakeld,
                IsRookverbodAfgekondigd = checklist.IsRookverbodAfgekondigd,
                ZijnRadarEnAndereElektrischeApparatenUit = checklist.ZijnRadarEnAndereElektrischeApparatenUit,
                ZijnDeurenEnRamenGesloten = checklist.ZijnDeurenEnRamenGesloten,
                IsOvervulbeveiligingBeproefd = checklist.IsOvervulbeveiligingBeproefd,
                IsUitschakelingPompVanafWalMogelijk = checklist.IsUitschakelingPompVanafWalMogelijk,
                IsGasafvoerleidingCorrectAangesloten = checklist.IsGasafvoerleidingCorrectAangesloten,
                IsDrukGasterugvoerleidingVeilig = checklist.IsDrukGasterugvoerleidingVeilig,
                IsVlamkerendeInrichtingAanwezig = checklist.IsVlamkerendeInrichtingAanwezig,
                IsVerblijftijdVastgesteldEnGedocumenteerd = checklist.IsVerblijftijdVastgesteldEnGedocumenteerd,
                IsLaadtemperatuurBinnenToegestaneBandbreedte = checklist.IsLaadtemperatuurBinnenToegestaneBandbreedte
            }).ToList();
        }

        public async Task<VeiligheidsChecklistDTO> GetVeiligheidsChecklistByIdAsync(int id)
        {
            var checklist = await _context.VeiligheidsChecklists.FindAsync(id);
            if (checklist == null) return null;

            return new VeiligheidsChecklistDTO
            {
                VeiligheidsChecklistId = checklist.VeiligheidsChecklistId,
                LadingId = checklist.LadingId,
                IsSchipGoedGemeerd = checklist.IsSchipGoedGemeerd,
                IsDoeltreffendeVerlichtingVerzekerd = checklist.IsDoeltreffendeVerlichtingVerzekerd,
                IsNooduitgangVrij = checklist.IsNooduitgangVrij,
                IsSchipWalVerbindingVeilig = checklist.IsSchipWalVerbindingVeilig,
                ZijnLaadarmenVrijBeweegbaar = checklist.ZijnLaadarmenVrijBeweegbaar,
                ZijnAansluitingenAfgeblind = checklist.ZijnAansluitingenAfgeblind,
                ZijnLeidingenInGoedeStaat = checklist.ZijnLeidingenInGoedeStaat,
                ZijnAlleKleppenGecontroleerd = checklist.ZijnAlleKleppenGecontroleerd,
                IsAlarmNoodstopBekend = checklist.IsAlarmNoodstopBekend,
                ZijnBrandblusApparatenBedrijfsklaar = checklist.ZijnBrandblusApparatenBedrijfsklaar,
                ZijnVerwarmingsapparatenUitgeschakeld = checklist.ZijnVerwarmingsapparatenUitgeschakeld,
                IsRookverbodAfgekondigd = checklist.IsRookverbodAfgekondigd,
                ZijnRadarEnAndereElektrischeApparatenUit = checklist.ZijnRadarEnAndereElektrischeApparatenUit,
                ZijnDeurenEnRamenGesloten = checklist.ZijnDeurenEnRamenGesloten,
                IsOvervulbeveiligingBeproefd = checklist.IsOvervulbeveiligingBeproefd,
                IsUitschakelingPompVanafWalMogelijk = checklist.IsUitschakelingPompVanafWalMogelijk,
                IsGasafvoerleidingCorrectAangesloten = checklist.IsGasafvoerleidingCorrectAangesloten,
                IsDrukGasterugvoerleidingVeilig = checklist.IsDrukGasterugvoerleidingVeilig,
                IsVlamkerendeInrichtingAanwezig = checklist.IsVlamkerendeInrichtingAanwezig,
                IsVerblijftijdVastgesteldEnGedocumenteerd = checklist.IsVerblijftijdVastgesteldEnGedocumenteerd,
                IsLaadtemperatuurBinnenToegestaneBandbreedte = checklist.IsLaadtemperatuurBinnenToegestaneBandbreedte
            };
        }

        public async Task AddVeiligheidsChecklistAsync(VeiligheidsChecklistDTO checklistDto)
        {
            var checklist = new VeiligheidsChecklist
            {
                LadingId = checklistDto.LadingId,
              
                IsSchipGoedGemeerd = checklistDto.IsSchipGoedGemeerd,
                IsDoeltreffendeVerlichtingVerzekerd = checklistDto.IsDoeltreffendeVerlichtingVerzekerd,
                IsNooduitgangVrij = checklistDto.IsNooduitgangVrij,
                IsSchipWalVerbindingVeilig = checklistDto.IsSchipWalVerbindingVeilig,
                ZijnLaadarmenVrijBeweegbaar = checklistDto.ZijnLaadarmenVrijBeweegbaar,
                ZijnAansluitingenAfgeblind = checklistDto.ZijnAansluitingenAfgeblind,
                ZijnLeidingenInGoedeStaat = checklistDto.ZijnLeidingenInGoedeStaat,
                ZijnAlleKleppenGecontroleerd = checklistDto.ZijnAlleKleppenGecontroleerd,
                IsAlarmNoodstopBekend = checklistDto.IsAlarmNoodstopBekend,
                ZijnBrandblusApparatenBedrijfsklaar = checklistDto.ZijnBrandblusApparatenBedrijfsklaar,
                ZijnVerwarmingsapparatenUitgeschakeld = checklistDto.ZijnVerwarmingsapparatenUitgeschakeld,
                IsRookverbodAfgekondigd = checklistDto.IsRookverbodAfgekondigd,
                ZijnRadarEnAndereElektrischeApparatenUit = checklistDto.ZijnRadarEnAndereElektrischeApparatenUit,
                ZijnDeurenEnRamenGesloten = checklistDto.ZijnDeurenEnRamenGesloten,
                IsOvervulbeveiligingBeproefd = checklistDto.IsOvervulbeveiligingBeproefd,
                IsUitschakelingPompVanafWalMogelijk = checklistDto.IsUitschakelingPompVanafWalMogelijk,
                IsGasafvoerleidingCorrectAangesloten = checklistDto.IsGasafvoerleidingCorrectAangesloten,
                IsDrukGasterugvoerleidingVeilig = checklistDto.IsDrukGasterugvoerleidingVeilig,
                IsVlamkerendeInrichtingAanwezig = checklistDto.IsVlamkerendeInrichtingAanwezig,
                IsVerblijftijdVastgesteldEnGedocumenteerd = checklistDto.IsVerblijftijdVastgesteldEnGedocumenteerd,
                IsLaadtemperatuurBinnenToegestaneBandbreedte = checklistDto.IsLaadtemperatuurBinnenToegestaneBandbreedte
            };

            _context.VeiligheidsChecklists.Add(checklist);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateVeiligheidsChecklistAsync(VeiligheidsChecklistDTO checklistDto)
        {
            var checklist = await _context.VeiligheidsChecklists.FindAsync(checklistDto.VeiligheidsChecklistId);
            if (checklist == null) return;

            checklist.LadingId = checklistDto.LadingId;
           
            checklist.IsSchipGoedGemeerd = checklistDto.IsSchipGoedGemeerd;
            checklist.IsDoeltreffendeVerlichtingVerzekerd = checklistDto.IsDoeltreffendeVerlichtingVerzekerd;
            checklist.IsNooduitgangVrij = checklistDto.IsNooduitgangVrij;
            checklist.IsSchipWalVerbindingVeilig = checklistDto.IsSchipWalVerbindingVeilig;
            checklist.ZijnLaadarmenVrijBeweegbaar = checklistDto.ZijnLaadarmenVrijBeweegbaar;
            checklist.ZijnAansluitingenAfgeblind = checklistDto.ZijnAansluitingenAfgeblind;
            checklist.ZijnLeidingenInGoedeStaat = checklistDto.ZijnLeidingenInGoedeStaat;
            checklist.ZijnAlleKleppenGecontroleerd = checklistDto.ZijnAlleKleppenGecontroleerd;
            checklist.IsAlarmNoodstopBekend = checklistDto.IsAlarmNoodstopBekend;
            checklist.ZijnBrandblusApparatenBedrijfsklaar = checklistDto.ZijnBrandblusApparatenBedrijfsklaar;
            checklist.ZijnVerwarmingsapparatenUitgeschakeld = checklistDto.ZijnVerwarmingsapparatenUitgeschakeld;
            checklist.IsRookverbodAfgekondigd = checklistDto.IsRookverbodAfgekondigd;
            checklist.ZijnRadarEnAndereElektrischeApparatenUit = checklistDto.ZijnRadarEnAndereElektrischeApparatenUit;
            checklist.ZijnDeurenEnRamenGesloten = checklistDto.ZijnDeurenEnRamenGesloten;
            checklist.IsOvervulbeveiligingBeproefd = checklistDto.IsOvervulbeveiligingBeproefd;
            checklist.IsUitschakelingPompVanafWalMogelijk = checklistDto.IsUitschakelingPompVanafWalMogelijk;
            checklist.IsGasafvoerleidingCorrectAangesloten = checklistDto.IsGasafvoerleidingCorrectAangesloten;
            checklist.IsDrukGasterugvoerleidingVeilig = checklistDto.IsDrukGasterugvoerleidingVeilig;
            checklist.IsVlamkerendeInrichtingAanwezig = checklistDto.IsVlamkerendeInrichtingAanwezig;
            checklist.IsVerblijftijdVastgesteldEnGedocumenteerd = checklistDto.IsVerblijftijdVastgesteldEnGedocumenteerd;
            checklist.IsLaadtemperatuurBinnenToegestaneBandbreedte = checklistDto.IsLaadtemperatuurBinnenToegestaneBandbreedte;

            _context.Entry(checklist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteVeiligheidsChecklistAsync(int id)
        {
            var checklist = await _context.VeiligheidsChecklists.FindAsync(id);
            if (checklist != null)
            {
                _context.VeiligheidsChecklists.Remove(checklist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
