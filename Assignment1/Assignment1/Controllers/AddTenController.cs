using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{

    public class AddTenController : ApiController
    {
        /// <summary>
        /// Add 10 to the ID, and return the sum.
        /// </summary>
        /// <param name="id">Input number</param>
        /// <returns>{id} + 10</returns>
        /// <example>
        /// GET localhost/AddTen/21 -> 31
        /// </example>
        public int Get(int id)
        {
            int sum = id + 10;

            return sum;
        }

    }
}
