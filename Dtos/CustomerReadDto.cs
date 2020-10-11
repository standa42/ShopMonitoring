using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMonitoring.Dtos
{
    public class CustomerReadDto
    {
        [Key]
        public int Id { get; set; }

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
