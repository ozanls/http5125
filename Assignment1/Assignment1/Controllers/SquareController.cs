﻿using System;
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
        /// This function will return the square of the ID provided.
        /// </summary>
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