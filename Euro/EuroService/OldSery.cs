//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EuroService
{
    using System;
    using System.Collections.Generic;
    
    public partial class OldSery
    {
        public int id { get; set; }
        public string code { get; set; }
        public int countryID { get; set; }
        public bool circulation { get; set; }
    
        public virtual Country Country { get; set; }
    }
}