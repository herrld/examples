using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Logic.Models
{
    public class Card
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public int manaCost { get; set; }
        public string color { get; set; }
        public int owned { get; set; }
        
    }
}
