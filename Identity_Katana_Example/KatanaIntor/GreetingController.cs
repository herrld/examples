﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaIntor
{
    public class GreetingController : ApiController
    {
        public Greeting Get()
        {
            return new Greeting { text = "Hello World" };
        }
    }
}
