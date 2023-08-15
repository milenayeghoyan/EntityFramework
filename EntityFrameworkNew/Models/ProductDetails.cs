using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNew.Models
{
    public class ProductDetails
    {
        public int ProductId { get; set; }
        public int ProductDetailsId { get; set; }
        public string Description { get; set; }

        public Product product { get; set; }
    }
}
