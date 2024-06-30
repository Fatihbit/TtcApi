using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TtcApi.Models
{
    public class Lading
    {
        public int LadingId { get; set; } // Primary Key
        public string ShipName { get; set; } // Foreign Key
        public string TerminalName { get; set; } // Foreign Key
        public string ProductName { get; set; } // Foreign Key
        public DateTime? Datum { get; set; }
        public string? Tijd { get; set; }
        public int? Hoeveelheid { get; set; }

        // Optional: Add navigation properties back if needed, with [JsonIgnore] attribute to avoid cyclic issues
        [JsonIgnore]
        public Ship Ship { get; set; }
        [JsonIgnore]
        public Terminal Terminal { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        [JsonIgnore]
        public ICollection<VeiligheidsChecklist> VeiligheidsChecklists { get; set; } = new List<VeiligheidsChecklist>();
    }
}
