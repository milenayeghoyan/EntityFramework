using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNew.Models
{
    public class CallDetail
    {
        [Key]
        public int CallID { get; set; }
        public string CallerNumber { get; set; }
        public string RecieverNumber { get; set; }
        public decimal CallDuration { get;set; }
        public string Email { get; set; }

    }
}
