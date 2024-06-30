namespace TtcApi.Models
{
    
    
        public class Terminal
        {
            public string TerminalName { get; set; } // Primary Key
            public string Email { get; set; }
            public string Location { get; set; }

            // Navigation properties
            public ICollection<Lading> Ladings { get; set; } = new List<Lading>();
            public ICollection<VeiligheidsChecklist> VeiligheidsChecklists { get; set; } = new List<VeiligheidsChecklist>();
        }
    }
    
