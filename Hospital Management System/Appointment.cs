//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital_Management_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int AppointmentID { get; set; }
        public Nullable<int> Patient { get; set; }
        public string Diagnosis { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Nullable<int> Employee { get; set; }
        public string Prescription { get; set; }
    
        public virtual Employee Employee1 { get; set; }
        public virtual Patient Patient1 { get; set; }
    }
}
