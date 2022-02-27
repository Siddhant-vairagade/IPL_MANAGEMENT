using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Matches = new HashSet<Match>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<Match> Matches { get; set; }
        [JsonIgnore]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
