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

    public class SubSysComponentsDropDownLink
    {
        public string System { get; set; }
        public string SubSystem { get; set; }
        public string Component { get; set; }

    }

}