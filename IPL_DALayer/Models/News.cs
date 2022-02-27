using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class News
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? NewsDate { get; set; }
        public int? MatchId { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual Match Match { get; set; }
    }
}
