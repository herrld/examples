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
        public string name { get; set; }
        public int? pin { get; set; }
    }
}