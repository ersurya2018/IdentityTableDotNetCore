using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        public string Name { get; set; }
        public string ClassCode { get; set; }
        public string Branch { get; set; }
    }
}
