using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Competenct_Management.Models
{
    public class User_Capability
    {
        
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        [Display(Name = "System"),
        Required
        ]public string System { get; set; }
        [Display(Name = "SubSystem")
        ]
        public string SubSystem { get; set; }
        [Display(Name = "Component")
        ]
        public string Component { get; set; }
        [Display(Name = "Description")
        ]public string Description { get; set; }
        [Display(Name ="Score")
        ]public int Score { get; set; }
        
    }

    public class Systemtbl
    {
        public string System { get; set; }
    }

    public class SubSystemtbl
    {
        public string SubSystem { get; set; }
    }

    public class Componenttbl
    {
        public string Component { get; set; }
    }

    public class Descriptiontbl
    {
        public string Description { get; set; }
    }

    public class Scoretbl
    {
        public int Score { get; set; }
    }
    
    ///public class User_CapabilityDBContext : DbContext
    ///{
    ///    public DbSet<User_Capability> Capabilities { get; set; }
   /// }
}