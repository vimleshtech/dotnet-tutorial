//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EBMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item_tax
    {
        public int item_tax_id { get; set; }
        public Nullable<decimal> item_tax_rate { get; set; }
        public Nullable<decimal> item_CGST { get; set; }
        public Nullable<decimal> item_SGST { get; set; }
        public Nullable<decimal> item_IGST { get; set; }
    }
}
