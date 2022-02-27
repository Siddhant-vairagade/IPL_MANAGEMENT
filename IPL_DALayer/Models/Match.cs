using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Match
    {
        public Match()
        {
            News = new HashSet<News>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? TeamOneId { get; set; }
        public int? TeamTwoId { get; set; }
        public int? VenueId { get; set; }
        public int? ScheduleId { get; set; }
        [JsonIgnore]
        public virtual Schedule Schedule { get; set; }
        [JsonIgnore]
        public virtual Team TeamOne { get; set; }
        [JsonIgnore]
        public virtual Team TeamTwo { get; set; }
        [JsonIgnore]
        public virtual Venue Venue { get; set; }
        [JsonIgnore]
        public virtual ICollection<News> News { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
