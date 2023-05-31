using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Models
{
    public class Response
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
   
}
