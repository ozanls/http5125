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
        /// Return a "Hello World!" greeting.
        /// </summary>
        /// <example>
        /// POST localhost/Greeting -> "Hello World!"
        /// </example>
        public string Post()
        {
            string greeting = "Hello World!";
            return greeting;
        }


        /// <summary>
        /// Return a greeting to a number of people, based on the ID.
        /// </summary>
        /// <param name="id">The number of people being greeted</param>
        /// <returns>"Greetings to {id} people!</returns>
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
