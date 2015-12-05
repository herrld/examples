using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using validate.Models;

namespace validate.DataAccess
{
    public class ValidateContext : DbContext
    {
        public ValidateContext()
        {
            Database.SetInitializer<ValidateContext>(new ValidateInitializer());
        }

        public DbSet<Test> tests { get; set; }
    }
}