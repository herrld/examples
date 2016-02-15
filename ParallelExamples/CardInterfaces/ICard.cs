using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInterfaces
{
    public interface ICard
    {
        int ID { get; set; }
        string name { get; set; }
    }
}
