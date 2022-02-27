using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int? MatchId { get; set; }
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        [JsonIgnore]
        public virtual TicketCategory Category { get; set; }
        [JsonIgnore]
        public virtual Match Match { get; set; }
    }
}
