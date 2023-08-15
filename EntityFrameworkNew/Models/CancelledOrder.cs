using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNew.Models
{
    public class CancelledOrder
    {
        [Key]
        public int Orderid { get; set; }
        public DateTime OrderDate { get; set; }
        public int Customerld { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public Customer2 Customer { get; set; }
    }
}
