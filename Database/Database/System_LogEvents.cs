//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class System_LogEvents
    {
        public System_LogEvents()
        {
            this.System_Logs = new HashSet<System_Logs>();
        }
    
        public int Id { get; set; }
        public string EventName { get; set; }
        public bool EnableLog { get; set; }
    
        public virtual ICollection<System_Logs> System_Logs { get; set; }
    }
}
