using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public class AttributesTestClass
    {
        [DisplayName("Test name")]
        public string name { get; set; }
    }
}
