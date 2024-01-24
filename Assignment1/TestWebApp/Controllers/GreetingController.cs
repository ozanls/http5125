using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace TestWebApp.Controllers
{
    public class GreetingController : ApiController
    {
        /*
        This function will return a "Hello World!" greeting.
        */
        public string Post()
        {
            string greeting = "Hello World";
            return greeting;
        }

        /*
        This function will return a greeting to a number of people, based on the ID.
        e.g. GET localhost/Greeting/3 -> "Greetings to 3 people!"
        */

        public string Get(int id)
        {
            string greeting = "Greetings to " + id + " people!";
            return greeting;

        }

    }
}
