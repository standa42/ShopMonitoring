using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonitoring.Models
{
    [Table("Customers")]
    public class Customer
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