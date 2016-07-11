using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace validate.Models
{
    public class Test
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 2)]
        public string name { get; set; }
        [Range(2,10)]
        public int? pin { get; set; }
    }
}