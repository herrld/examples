using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Logic.DataAccess
{
    public class cardsInitializer : DropCreateDatabaseAlways<cardsContext>
    {
        protected override void Seed(cardsContext context)
        {
            base.Seed(context);
        }
    }
}
