using Data;
using DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class DataContext : DbContext
    {

        public virtual DbSet<Card> Cards { get; set; }


        public DataContext():base() { }
        public DataContext(string connection):base(connection)
        {
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>(true));
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }
    }
}
