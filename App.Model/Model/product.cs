//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Models.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public product()
        {
            this.sales = new HashSet<sale>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> quantity { get; set; }
        public string unit_measure { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<int> location_id { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string currency { get; set; }
        public string img_url { get; set; }
        public Nullable<bool> is_active { get; set; }
    
        public virtual category category { get; set; }
        public virtual location location { get; set; }
        public virtual ICollection<sale> sales { get; set; }
    }
}
