using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Logic.Models;

namespace Logic.DataAccess
{
    public class cardsContext: DbContext
    {
        
        public System.Data.Entity.DbSet<Logic.Models.Card> Cards { get; set; }
    }
}
