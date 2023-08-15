using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNew.Models
{
    public class FeaturedProduct
    {
        
        public int id { get; set; }
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal StockQuantity { get; set; }
        public ProductDetails productDetails { get; set; }
        public string Category { get; set; }
    }
}
