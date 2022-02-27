using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Team
    {
        public Team()
        {
            MatchTeamOnes = new HashSet<Match>();
            MatchTeamTwos = new HashSet<Match>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public string GroundName { get; set; }
        public string Franchises { get; set; }
        [JsonIgnore]

        public virtual Statistic Statistic { get; set; }
        [JsonIgnore]
        public virtual ICollection<Match> MatchTeamOnes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Match> MatchTeamTwos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }
    }
}
