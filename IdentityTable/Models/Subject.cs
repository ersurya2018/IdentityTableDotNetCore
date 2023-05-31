using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Models
{
    public class Subject
    {
        [Key]
        public int SubId { get; set; }
        public string SubjectName { get; set; }
        public Student SId { get; set; }
    }
}
