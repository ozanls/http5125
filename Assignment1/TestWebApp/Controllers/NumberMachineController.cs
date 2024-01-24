using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace TestWebApp.Controllers
{
    public class NumberMachineController : ApiController
    {
        /*
        This function will always return the number 2.
        e.g. GET localhost/NumberMachine/10 -> 2
        */

        public int Get(int id)
        {
            int product = (((id * 10) + 20)/ 10) - id;

            return product;
        }

    }
}
