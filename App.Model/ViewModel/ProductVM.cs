using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.ViewModel
{
   public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string Currency { get; set; }
        public string UnitMeasure { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string ImgUrl { get; set; }
        public bool? IsActive { get; set; }
        public int? LocationId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }     
    }
}
