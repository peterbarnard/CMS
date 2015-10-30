using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competenct_Management.Controllers
{
    public class SubSystemDropDownLink
    {
        public string System { get; set; }
        public string SubSystem { get; set; }
    }

    public class Component
    {
        public string componentId { get; set; }
        public string component { get; set; }

    }

    public class Description
    {
        public string descriptionId { get; set; }
        public string description { get; set; }
    }

  
}