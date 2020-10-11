using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMonitoring.Dtos
{
    public class CustomerCreateDto
    {
        [Required]
        public DateTime VisitDateTime { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool WasSatisfied { get; set; }

        [Required]
        public char Sex { get; set; }
    }
}
