using System;
using System.Collections.Generic;

namespace Project_PRN231_API.Models
{
    public partial class User
    {
        public User()
        {
            CareProcesses = new HashSet<CareProcess>();
            HarvestProcesses = new HashSet<HarvestProcess>();
            PlantProcesses = new HashSet<PlantProcess>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<CareProcess> CareProcesses { get; set; }
        public virtual ICollection<HarvestProcess> HarvestProcesses { get; set; }
        public virtual ICollection<PlantProcess> PlantProcesses { get; set; }
    }
}
