using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNew.Models
{
    public class Order
    {
        [Key]
        public int Orderid { get; set; }
        public DateTime OrderDate { get; set; }
        public int Customerld { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public Customer2 Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
      
        public int CustomerId { get; set; }
    }
}
