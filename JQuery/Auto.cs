//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JQuery
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auto
    {
        public int aut_id { get; set; }
        public string aut_placa { get; set; }
        public string aut_modelo { get; set; }
        public string aut_color { get; set; }
        public Nullable<int> per_id { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}
