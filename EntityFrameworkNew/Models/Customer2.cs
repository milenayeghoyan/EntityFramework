using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNew.Models
{
    public class Customer2
    {
        [Key]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; }
        public bool IsDeleted { get; set; }
    }
}
