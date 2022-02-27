using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public int? VenueId { get; set; }
        public DateTime? MatchDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        [JsonIgnore]
        public virtual Venue Venue { get; set; }
        [JsonIgnore]
        public virtual ICollection<Match> Matches { get; set; }
    }
}
