using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Competenct_Management.Models
{
    public class User_Capability
    {
        [Key]
        public string ID { get; set; }
        public string System { get; set; }
        public string SubSystem { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public int score { get; set; }
    }

    public class User_CapabilityDBContext : DbContext
    {
        public DbSet<User_Capability> Capabilities { get; set; }
    }
}