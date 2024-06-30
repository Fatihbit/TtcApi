namespace TtcApi.DTOs
{
    public class VeiligheidsChecklistDTO
    {
        public int VeiligheidsChecklistId { get; set; }
        public int LadingId { get; set; }
        public bool IsSchipGoedGemeerd { get; set; }
        public bool IsDoeltreffendeVerlichtingVerzekerd { get; set; }
        public bool IsNooduitgangVrij { get; set; }
        public bool IsSchipWalVerbindingVeilig { get; set; }
        public bool ZijnLaadarmenVrijBeweegbaar { get; set; }
        public bool ZijnAansluitingenAfgeblind { get; set; }
        public bool ZijnLeidingenInGoedeStaat { get; set; }
        public bool ZijnAlleKleppenGecontroleerd { get; set; }
        public bool IsAlarmNoodstopBekend { get; set; }
        public bool ZijnBrandblusApparatenBedrijfsklaar { get; set; }
        public bool ZijnVerwarmingsapparatenUitgeschakeld { get; set; }
        public bool IsRookverbodAfgekondigd { get; set; }
        public bool ZijnRadarEnAndereElektrischeApparatenUit { get; set; }
        public bool ZijnDeurenEnRamenGesloten { get; set; }
        public bool IsOvervulbeveiligingBeproefd { get; set; }
        public bool IsUitschakelingPompVanafWalMogelijk { get; set; }
        public bool IsGasafvoerleidingCorrectAangesloten { get; set; }
        public bool IsDrukGasterugvoerleidingVeilig { get; set; }
        public bool IsVlamkerendeInrichtingAanwezig { get; set; }
        public bool IsVerblijftijdVastgesteldEnGedocumenteerd { get; set; }
        public bool IsLaadtemperatuurBinnenToegestaneBandbreedte { get; set; }
    }
}
