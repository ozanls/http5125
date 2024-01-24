using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// This function will always return the number 2.
        /// </summary>
        /// <param name="id">Input number</param>
        /// <returns>2</returns>
        /// <example>
        /// GET localhost/NumberMachine/10 -> 2
        /// </example>

        public int Get(int id)
        {
            int product = (((id * 10) + 20) / 10) - id;

            return product;
        }
    }
}
