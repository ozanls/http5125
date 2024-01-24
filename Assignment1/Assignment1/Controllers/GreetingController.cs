using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    
    public class GreetingController : ApiController
    {
        /// <summary>
        /// This function will return a "Hello World!" greeting.
        /// </summary>
        /// <example>
        /// GET localhost/Greeting -> "Hello World!"
        /// </example>
        public string Post()
        {
            string greeting = "Hello World";
            return greeting;
        }

        /// <summary>
        /// This function will return a greeting to a number of people, based on the ID.
        /// </summary>
        /// <example>
        /// GET localhost/Greeting/3 -> "Greetings to 3 people!"
        /// </example>
        public string Get(int id)
        {
            string greeting = "Greetings to " + id + " people!";
            return greeting;

        }

    }
}
