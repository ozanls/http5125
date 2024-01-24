using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class SquareController : ApiController
    {
        /// <summary>
        /// Return the square of the number provided.
        /// </summary>
        /// <param name="id">Input number</param>
        /// <returns>{id}^2</returns>
        /// <example>
        /// GET localhost/Square/10 -> 100
        /// </example>

        public int Get(int id)
        {
            int product = id * id;

            return product;
        }
    }
}
