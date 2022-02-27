using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public int? TeamId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? SpecialtyId { get; set; }
        [JsonIgnore]
        public virtual Specialty Specialty { get; set; }
        [JsonIgnore]
        public virtual Team Team { get; set; }
    }
}
