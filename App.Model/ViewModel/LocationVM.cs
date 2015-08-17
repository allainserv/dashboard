using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.ViewModel
{
    public class LocationVM
    {
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }
    }
}
