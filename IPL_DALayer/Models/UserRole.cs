using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class UserRole
    {
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
