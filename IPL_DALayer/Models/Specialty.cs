using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            Players = new HashSet<Player>();
        }

        public int SpecialityId { get; set; }
        public string SpecialityDescription { get; set; }
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }
    }
}
