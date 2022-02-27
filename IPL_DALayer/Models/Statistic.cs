using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Statistic
    {
        public int TeamId { get; set; }
        public int? Played { get; set; }
        public int? Won { get; set; }
        public int? Lost { get; set; }
        public int? Tied { get; set; }
        public decimal? NR { get; set; }
        public decimal? NetRr { get; set; }
        public int? ForAgainst { get; set; }
        public int? Pts { get; set; }
        [JsonIgnore]
        public virtual Team Team { get; set; }
    }
}
