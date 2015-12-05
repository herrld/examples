using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using validate.Models;

namespace validate.DataAccess
{
    public class ValidateInitializer :DropCreateDatabaseAlways<ValidateContext>
    {
        protected override void Seed(ValidateContext context)
        {
            context.tests.Add(new Test
            {
                name = "first item"
            });
            context.SaveChanges();
        }
    }
}