using CardInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class MagicTheGatheringCard: ICard
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string layout { get; set; }
        public string manaCost { get; set; }
    }
}
